using QuietGuard;

namespace QuietGuard.Tests;

public class IoavHeadlineCopyTests
{
    [Fact]
    public void Enabled_matches_ioav_quiet_copy()
    {
        Assert.Equal(IoavQuietCopy.IsQuiet(true), IoavHeadlineCopy.IsQuiet(true));
        Assert.Equal(IoavQuietCopy.Headline(true), IoavHeadlineCopy.Headline(true));
    }

    [Fact]
    public void Disabled_matches_ioav_quiet_copy()
    {
        Assert.Equal(IoavQuietCopy.IsQuiet(false), IoavHeadlineCopy.IsQuiet(false));
        Assert.Equal(IoavQuietCopy.Headline(false), IoavHeadlineCopy.Headline(false));
    }
}
