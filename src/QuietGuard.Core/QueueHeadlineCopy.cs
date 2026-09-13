namespace QuietGuard;

public static class QueueHeadlineCopy
{
    public static bool ShouldQueue(string path) => DownloadQueueCopy.ShouldQueue(path);

    public static string Headline(string path) => DownloadQueueCopy.Headline(path);
}
