using QuietGuard;

namespace QuietGuard.Tests;

public class WatchDebounceCopyTests
{
    [Fact]
    public void Hint_matches_watch_toggle_debounce_hint()
    {
        Assert.Equal(WatchToggleCopy.DebounceHint(), WatchDebounceCopy.Hint());
        Assert.Contains($"{WatchDebounceCopy.Delay().TotalMilliseconds:0}", WatchDebounceCopy.Hint());
    }

    [Fact]
    public void Checkbox_matches_watch_toggle_checkbox()
    {
        Assert.Equal(WatchToggleCopy.Checkbox(), WatchDebounceCopy.Checkbox());
    }

    [Fact]
    public void Delay_matches_download_scan_advisor_debounce()
    {
        Assert.Equal(DownloadScanAdvisor.Debounce, WatchDebounceCopy.Delay());
    }
}
