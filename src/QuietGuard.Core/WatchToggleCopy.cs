namespace QuietGuard;

public static class WatchToggleCopy
{
    public static string Checkbox() => "다운로드 폴더 감시 (실행 파일만, 조용히 검사)";

    public static string DebounceHint() => $"대기 {DownloadScanAdvisor.Debounce.TotalMilliseconds:0}ms";
}
