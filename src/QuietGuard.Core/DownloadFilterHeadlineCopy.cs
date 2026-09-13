namespace QuietGuard;

public static class DownloadFilterHeadlineCopy
{
    public static bool ShouldScan(string path) => DownloadFilterCopy.ShouldScan(path);

    public static string Headline(string path) => DownloadFilterCopy.Headline(path);
}
