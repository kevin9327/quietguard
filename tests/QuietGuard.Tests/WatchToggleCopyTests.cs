using QuietGuard;

namespace QuietGuard.Tests;

public class WatchToggleCopyTests
{
    [Fact]
    public void Checkbox_is_quiet_download_folder_watch()
    {
        var text = WatchToggleCopy.Checkbox();

        Assert.Equal("다운로드 폴더 감시 (실행 파일만, 조용히 검사)", text);
        Assert.Contains("다운로드", text);
    }

    [Fact]
    public void DebounceHint_uses_shipped_debounce_milliseconds()
    {
        var ms = DownloadScanAdvisor.Debounce.TotalMilliseconds;
        var hint = WatchToggleCopy.DebounceHint();

        Assert.Contains($"{ms:0}", hint);
        Assert.Contains("ms", hint);
        Assert.Equal($"대기 {ms:0}ms", hint);
    }
}
