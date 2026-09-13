namespace QuietGuard;

public sealed record ScanScheduleDecision(bool ShouldScan, bool NotifyUser, string Reason);

public static class ScanScheduler
{
    public static readonly TimeSpan DefaultInterval = TimeSpan.FromHours(24);

    public static ScanScheduleDecision Decide(
        DateTime utcNow,
        DateTime? lastQuickScanUtc,
        TimeSpan interval,
        ProtectionLevel level)
    {
        if (lastQuickScanUtc is { } last && utcNow - last < interval)
            return new ScanScheduleDecision(false, false, "아직 검사 간격이 지나지 않아 대기합니다.");

        if (level == ProtectionLevel.Protected)
            return new ScanScheduleDecision(true, false, "보호 중이므로 조용히 검사합니다.");

        return new ScanScheduleDecision(true, true, "보호가 약해 검사 후 알림을 보냅니다.");
    }

    public static DateTime? NextDueUtc(DateTime? lastQuickScanUtc, TimeSpan interval) =>
        lastQuickScanUtc is { } last ? last + interval : DateTime.MinValue;

    public static string MpCmdArgumentsForScheduledQuickScan() => "-Scan -ScanType 1";
}
