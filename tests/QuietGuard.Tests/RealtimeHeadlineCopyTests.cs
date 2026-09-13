using QuietGuard;

namespace QuietGuard.Tests;

public class RealtimeHeadlineCopyTests
{
    [Fact]
    public void Enabled_matches_realtime_quiet_copy()
    {
        Assert.Equal(RealtimeQuietCopy.IsQuiet(true), RealtimeHeadlineCopy.IsQuiet(true));
        Assert.Equal(RealtimeQuietCopy.Headline(true), RealtimeHeadlineCopy.Headline(true));
        Assert.Equal(RealtimeProtectionCopy.IsQuiet(true), RealtimeHeadlineCopy.IsQuiet(true));
        Assert.Equal(RealtimeProtectionCopy.Headline(true), RealtimeHeadlineCopy.Headline(true));
        Assert.True(RealtimeHeadlineCopy.IsQuiet(true));
        Assert.Equal("실시간 보호 켜짐", RealtimeHeadlineCopy.Headline(true));
    }

    [Fact]
    public void Disabled_matches_realtime_quiet_copy()
    {
        Assert.Equal(RealtimeQuietCopy.IsQuiet(false), RealtimeHeadlineCopy.IsQuiet(false));
        Assert.Equal(RealtimeQuietCopy.Headline(false), RealtimeHeadlineCopy.Headline(false));
        Assert.Equal(RealtimeProtectionCopy.IsQuiet(false), RealtimeHeadlineCopy.IsQuiet(false));
        Assert.Equal(RealtimeProtectionCopy.Headline(false), RealtimeHeadlineCopy.Headline(false));
        Assert.False(RealtimeHeadlineCopy.IsQuiet(false));
        Assert.Equal("실시간 보호가 꺼져 있습니다", RealtimeHeadlineCopy.Headline(false));
    }

    [Fact]
    public void Status_overload_matches_quiet_and_protection_copy()
    {
        var status = new DefenderStatus(
            true, false, true, true, true, true, false,
            DateTime.Now, DateTime.Now, DateTime.Now, "1", "1", "0");
        Assert.Equal(RealtimeQuietCopy.IsQuiet(status), RealtimeHeadlineCopy.IsQuiet(status));
        Assert.Equal(RealtimeProtectionCopy.IsQuiet(status), RealtimeHeadlineCopy.IsQuiet(status));
        Assert.False(RealtimeHeadlineCopy.IsQuiet(status));
    }
}
