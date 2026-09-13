using QuietGuard;

namespace QuietGuard.Tests;

public class WatchDebounceHeadlineCopyTests
{
    [Fact]
    public void Hint_and_delay_equal_watch_debounce_copy()
    {
        Assert.Equal(WatchDebounceCopy.Hint(), WatchDebounceHeadlineCopy.Hint());
        Assert.Equal(WatchDebounceCopy.Delay(), WatchDebounceHeadlineCopy.Delay());
        Assert.Equal(DownloadScanAdvisor.Debounce, WatchDebounceHeadlineCopy.Delay());
        Assert.Equal(TimeSpan.FromMilliseconds(1500), WatchDebounceHeadlineCopy.Delay());
        Assert.Contains("ms", WatchDebounceHeadlineCopy.Hint());
    }

    [Fact]
    public void Checkbox_equals_watch_toggle()
    {
        Assert.Equal(WatchDebounceCopy.Checkbox(), WatchDebounceHeadlineCopy.Checkbox());
        Assert.Equal(WatchToggleCopy.Checkbox(), WatchDebounceHeadlineCopy.Checkbox());
        Assert.Contains("다운로드", WatchDebounceHeadlineCopy.Checkbox());
    }
}
