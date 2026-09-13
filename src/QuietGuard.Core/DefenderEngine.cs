using System.Diagnostics;
using System.Management;

namespace QuietGuard;

public sealed class DefenderEngine
{
    public DefenderStatus ReadStatus()
    {
        using var searcher = new ManagementObjectSearcher(
            @"root\Microsoft\Windows\Defender",
            "SELECT * FROM MSFT_MpComputerStatus");
        using var results = searcher.Get();
        foreach (ManagementObject obj in results)
        {
            using (obj)
            {
                return MapStatus(obj);
            }
        }

        throw new InvalidOperationException("Microsoft Defender 상태를 읽을 수 없습니다. WinDefend 서비스가 켜져 있는지 확인하세요.");
    }

    public IReadOnlyList<ThreatInfo> ReadThreats()
    {
        try
        {
            using var searcher = new ManagementObjectSearcher(
                @"root\Microsoft\Windows\Defender",
                "SELECT * FROM MSFT_MpThreatDetection");
            using var results = searcher.Get();
            var list = new List<ThreatInfo>();
            foreach (ManagementObject obj in results)
            {
                using (obj)
                {
                    list.Add(new ThreatInfo(
                        ReadString(obj, "ThreatName") ?? ReadString(obj, "ThreatID") ?? "알 수 없는 위협",
                        FirstResource(obj) ?? "",
                        ReadString(obj, "ThreatStatusID") ?? "",
                        ReadDate(obj, "InitialDetectionTime")));
                }
            }

            return list
                .OrderByDescending(t => t.DetectedAt ?? DateTime.MinValue)
                .Take(20)
                .ToList();
        }
        catch (ManagementException)
        {
            return [];
        }
    }

    public Task<int> QuickScanAsync(CancellationToken cancellationToken = default) =>
        RunMpCmdAsync("-Scan -ScanType 1", cancellationToken);

    public Task<int> UpdateSignaturesAsync(CancellationToken cancellationToken = default) =>
        RunMpCmdAsync("-SignatureUpdate", cancellationToken);

    public Task<int> ScanFileAsync(string path, CancellationToken cancellationToken = default)
    {
        if (!DownloadScanAdvisor.ShouldQueue(path))
            return Task.FromResult(0);

        return RunMpCmdAsync($"-Scan -ScanType 3 -File \"{path}\"", cancellationToken);
    }

    public Task<int> ApplyAsync(ThreatActionKind kind, ThreatInfo threat, CancellationToken cancellationToken = default)
    {
        var plan = ThreatActions.Plan(kind, threat);
        if (plan.FileName.Equals("MpCmdRun.exe", StringComparison.OrdinalIgnoreCase))
            return RunMpCmdAsync(plan.Arguments, cancellationToken);
        return RunProcessAsync(plan, cancellationToken);
    }

    public async Task<ScanScheduleDecision> RunScheduledScanIfDueAsync(
        ProtectionLevel level,
        DateTime utcNow,
        CancellationToken cancellationToken = default)
    {
        var last = LastScanStore.Read();
        var decision = ScanScheduler.Decide(utcNow, last, ScanScheduler.DefaultInterval, level);
        if (!decision.ShouldScan)
            return decision;

        var code = await RunMpCmdAsync(ScanScheduler.MpCmdArgumentsForScheduledQuickScan(), cancellationToken)
            .ConfigureAwait(false);
        if (code == 0)
            LastScanStore.Write(utcNow);
        return decision;
    }

    public static string ResolveMpCmdRun()
    {
        var candidates = new[]
        {
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Windows Defender", "MpCmdRun.exe"),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Windows Defender", "MpCmdRun.exe"),
            @"C:\Program Files\Windows Defender\MpCmdRun.exe"
        };

        return candidates.FirstOrDefault(File.Exists)
            ?? throw new FileNotFoundException("MpCmdRun.exe를 찾지 못했습니다.");
    }

    private static async Task<int> RunMpCmdAsync(string arguments, CancellationToken cancellationToken)
    {
        var start = new ProcessStartInfo
        {
            FileName = ResolveMpCmdRun(),
            Arguments = arguments,
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };

        using var process = Process.Start(start)
            ?? throw new InvalidOperationException("MpCmdRun.exe를 시작하지 못했습니다.");
        await process.WaitForExitAsync(cancellationToken).ConfigureAwait(false);
        return process.ExitCode;
    }

    private static async Task<int> RunProcessAsync(ThreatActionPlan plan, CancellationToken cancellationToken)
    {
        var start = new ProcessStartInfo
        {
            FileName = plan.FileName,
            Arguments = plan.Arguments,
            UseShellExecute = plan.RequiresElevation,
            CreateNoWindow = !plan.RequiresElevation
        };
        if (plan.RequiresElevation)
            start.Verb = "runas";
        else
        {
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
        }

        using var process = Process.Start(start)
            ?? throw new InvalidOperationException($"{plan.FileName}을(를) 시작하지 못했습니다.");
        await process.WaitForExitAsync(cancellationToken).ConfigureAwait(false);
        return process.ExitCode;
    }

    internal static DefenderStatus MapStatus(ManagementBaseObject obj) =>
        new(
            ReadBool(obj, "AntivirusEnabled"),
            ReadBool(obj, "RealTimeProtectionEnabled"),
            ReadBool(obj, "IoavProtectionEnabled"),
            ReadBool(obj, "BehaviorMonitorEnabled"),
            ReadBool(obj, "NISEnabled"),
            ReadBool(obj, "IsTamperProtected"),
            ReadBool(obj, "DefenderSignaturesOutOfDate"),
            ReadDate(obj, "AntivirusSignatureLastUpdated"),
            ReadDate(obj, "QuickScanEndTime") ?? ReadDate(obj, "LastQuickScanStartTime"),
            ReadDate(obj, "FullScanEndTime") ?? ReadDate(obj, "LastFullScanStartTime"),
            ReadString(obj, "AMEngineVersion"),
            ReadString(obj, "AntivirusSignatureVersion"),
            ReadString(obj, "ComputerState"));

    private static bool ReadBool(ManagementBaseObject obj, string name)
    {
        try
        {
            return obj[name] is bool b && b;
        }
        catch (ManagementException)
        {
            return false;
        }
    }

    private static string? ReadString(ManagementBaseObject obj, string name)
    {
        try
        {
            return obj[name]?.ToString();
        }
        catch (ManagementException)
        {
            return null;
        }
    }

    private static DateTime? ReadDate(ManagementBaseObject obj, string name)
    {
        try
        {
            var value = obj[name];
            return value switch
            {
                DateTime dt => dt,
                string s when DateTime.TryParse(s, out var parsed) => parsed,
                _ => null
            };
        }
        catch (ManagementException)
        {
            return null;
        }
    }

    private static string? FirstResource(ManagementBaseObject obj)
    {
        try
        {
            if (obj["Resources"] is string[] resources && resources.Length > 0)
                return resources[0];
            return obj["Resources"]?.ToString();
        }
        catch (ManagementException)
        {
            return null;
        }
    }
}
