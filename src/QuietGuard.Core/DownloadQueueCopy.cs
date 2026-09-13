namespace QuietGuard;

public static class DownloadQueueCopy
{
    public static bool ShouldQueue(string path) => DownloadScanAdvisor.ShouldQueue(path);

    public static string Headline(string path) =>
        ShouldQueue(path) ? "다운로드 검사 대기" : "검사 대상 아님";
}
