namespace QuietGuard;

public static class DownloadScanCopy
{
    public static bool ShouldNotify(int mpCmdExitCode) =>
        DownloadScanAdvisor.ShouldNotify(mpCmdExitCode);

    public static string FormatResult(string path, int mpCmdExitCode) =>
        DownloadScanAdvisor.FormatResult(path, mpCmdExitCode);

    public static TimeSpan Debounce => DownloadScanAdvisor.Debounce;
}
