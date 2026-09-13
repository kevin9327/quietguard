namespace QuietGuard;

public static class DownloadFilterCopy
{
    public static bool ShouldScan(string path) => DownloadWatchFilter.ShouldScan(path);

    public static string Headline(string path) =>
        ShouldScan(path) ? "검사 대상" : "건너뜀";
}
