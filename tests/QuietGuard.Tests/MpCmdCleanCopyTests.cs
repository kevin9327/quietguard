using QuietGuard;

namespace QuietGuard.Tests;

public class MpCmdCleanCopyTests
{
    [Fact]
    public void Clean_zero_matches_MpCmdExit_and_is_quiet()
    {
        Assert.Equal(MpCmdExit.IsClean(0), MpCmdCleanCopy.IsClean(0));
        Assert.True(MpCmdCleanCopy.IsClean(0));
        Assert.Equal(MpCmdExit.Describe(0), MpCmdCleanCopy.Headline(0));
        Assert.Equal(BalloonPolicy.ShowForMpCmd(0), MpCmdCleanCopy.Notify(0));
        Assert.False(MpCmdCleanCopy.Notify(0));
    }

    [Fact]
    public void Threat_code_two_notifies()
    {
        Assert.Equal(MpCmdExit.IsThreatDetected(2), !MpCmdCleanCopy.IsClean(2));
        Assert.True(MpCmdExit.IsThreatDetected(2));
        Assert.Equal(MpCmdExit.Describe(2), MpCmdCleanCopy.Headline(2));
        Assert.True(MpCmdCleanCopy.Notify(2));
        Assert.True(BalloonPolicy.ShowForMpCmd(2));
    }
}
