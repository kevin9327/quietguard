using QuietGuard;

namespace QuietGuard.Tests;

public class WatchCooldownCopyTests
{
    [Fact]
    public void Cooldown_equals_30_seconds_and_advisor()
    {
        Assert.Equal(TimeSpan.FromSeconds(30), WatchCooldownCopy.Cooldown);
        Assert.Equal(DownloadScanAdvisor.Cooldown, WatchCooldownCopy.Cooldown);
    }

    [Fact]
    public void Debounce_equals_1500ms_and_advisor_and_watch_debounce_copy_delay()
    {
        Assert.Equal(TimeSpan.FromMilliseconds(1500), WatchCooldownCopy.Debounce);
        Assert.Equal(DownloadScanAdvisor.Debounce, WatchCooldownCopy.Debounce);
        Assert.Equal(WatchDebounceCopy.Delay(), WatchCooldownCopy.Debounce);
    }
}
