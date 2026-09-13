namespace QuietGuard;

public static class DownloadScanAdvisor
{
    public static readonly TimeSpan Debounce = TimeSpan.FromMilliseconds(1500);
    public static readonly TimeSpan Cooldown = TimeSpan.FromSeconds(30);

    public static bool ShouldQueue(string path) =>
        DownloadWatchFilter.ShouldScan(path) && ScanPathSafety.IsSafeCustomScanTarget(path);

    public static bool ShouldNotify(int mpCmdExitCode) => !MpCmdExit.IsClean(mpCmdExitCode);

    public static string FormatResult(string path, int mpCmdExitCode)
    {
        var name = Path.GetFileName(path);
        return mpCmdExitCode == 0
            ? $"다운로드 검사 완료: {name}"
            : $"다운로드 검사 코드 {mpCmdExitCode}: {name}";
    }
}
