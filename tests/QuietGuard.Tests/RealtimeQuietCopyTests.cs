using QuietGuard;

namespace QuietGuard.Tests;

public class RealtimeQuietCopyTests
{
    [Fact]
    public void Enabled_matches_realtime_protection_copy()
    {
        Assert.Equal(RealtimeProtectionCopy.IsQuiet(true), RealtimeQuietCopy.IsQuiet(true));
        Assert.Equal(RealtimeProtectionCopy.Headline(true), RealtimeQuietCopy.Headline(true));
    }

    [Fact]
    public void Disabled_matches_realtime_protection_copy()
    {
        Assert.Equal(RealtimeProtectionCopy.IsQuiet(false), RealtimeQuietCopy.IsQuiet(false));
        Assert.Equal(RealtimeProtectionCopy.Headline(false), RealtimeQuietCopy.Headline(false));
    }

    [Fact]
    public void Status_overload_matches_protection_copy()
    {
        var status = new DefenderStatus(
            true, false, true, true, true, true, false,
            DateTime.Now, DateTime.Now, DateTime.Now, "1", "1", "0");
        Assert.Equal(RealtimeProtectionCopy.IsQuiet(status), RealtimeQuietCopy.IsQuiet(status));
    }
}
