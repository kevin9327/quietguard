using QuietGuard;

namespace QuietGuard.Tests;

public class MpCmdCleanHeadlineCopyTests
{
    [Fact]
    public void Clean_zero_matches_copy_and_exit()
    {
        Assert.True(MpCmdCleanHeadlineCopy.IsClean(0));
        Assert.Equal(MpCmdCleanCopy.IsClean(0), MpCmdCleanHeadlineCopy.IsClean(0));
        Assert.Equal(MpCmdExit.IsClean(0), MpCmdCleanHeadlineCopy.IsClean(0));
        Assert.Equal("이상 없음", MpCmdCleanHeadlineCopy.Headline(0));
        Assert.Equal(MpCmdCleanCopy.Headline(0), MpCmdCleanHeadlineCopy.Headline(0));
        Assert.Equal(MpCmdExit.Describe(0), MpCmdCleanHeadlineCopy.Headline(0));
        Assert.False(MpCmdCleanHeadlineCopy.Notify(0));
        Assert.Equal(MpCmdCleanCopy.Notify(0), MpCmdCleanHeadlineCopy.Notify(0));
    }

    [Fact]
    public void Threat_code_two_notifies()
    {
        Assert.False(MpCmdCleanHeadlineCopy.IsClean(2));
        Assert.Equal(MpCmdCleanCopy.IsClean(2), MpCmdCleanHeadlineCopy.IsClean(2));
        Assert.Equal(MpCmdExit.IsClean(2), MpCmdCleanHeadlineCopy.IsClean(2));
        Assert.True(MpCmdExit.IsThreatDetected(2));
        Assert.Equal("위협 발견", MpCmdCleanHeadlineCopy.Headline(2));
        Assert.Equal(MpCmdCleanCopy.Headline(2), MpCmdCleanHeadlineCopy.Headline(2));
        Assert.Equal(MpCmdExit.Describe(2), MpCmdCleanHeadlineCopy.Headline(2));
        Assert.True(MpCmdCleanHeadlineCopy.Notify(2));
        Assert.Equal(MpCmdCleanCopy.Notify(2), MpCmdCleanHeadlineCopy.Notify(2));
    }
}
