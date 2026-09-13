using QuietGuard;

namespace QuietGuard.Tests;

public class WatchToggleHeadlineCopyTests
{
    [Fact]
    public void Checkbox_equals_watch_toggle_copy_and_contains_download()
    {
        var text = WatchToggleHeadlineCopy.Checkbox();

        Assert.Equal(WatchToggleCopy.Checkbox(), text);
        Assert.Contains("다운로드", text);
    }

    [Fact]
    public void DebounceHint_equals_watch_toggle_copy_and_contains_ms()
    {
        var hint = WatchToggleHeadlineCopy.DebounceHint();

        Assert.Equal(WatchToggleCopy.DebounceHint(), hint);
        Assert.Contains("ms", hint);
    }
}
