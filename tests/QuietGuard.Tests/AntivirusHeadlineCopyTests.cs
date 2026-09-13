using QuietGuard;

namespace QuietGuard.Tests;

public class AntivirusHeadlineCopyTests
{
    [Fact]
    public void Enabled_is_quiet_and_equals_antivirus_quiet_copy()
    {
        Assert.True(AntivirusHeadlineCopy.IsQuiet(true));
        Assert.Equal(AntivirusQuietCopy.IsQuiet(true), AntivirusHeadlineCopy.IsQuiet(true));
        Assert.Equal(AntivirusEnabledCopy.IsQuiet(true), AntivirusHeadlineCopy.IsQuiet(true));
        Assert.Equal(AntivirusQuietCopy.Headline(true), AntivirusHeadlineCopy.Headline(true));
        Assert.Equal(AntivirusEnabledCopy.Headline(true), AntivirusHeadlineCopy.Headline(true));
    }

    [Fact]
    public void Disabled_is_not_quiet()
    {
        Assert.False(AntivirusHeadlineCopy.IsQuiet(false));
        Assert.Equal(AntivirusQuietCopy.IsQuiet(false), AntivirusHeadlineCopy.IsQuiet(false));
        Assert.Equal(AntivirusQuietCopy.Headline(false), AntivirusHeadlineCopy.Headline(false));
        Assert.Equal(AntivirusEnabledCopy.Headline(false), AntivirusHeadlineCopy.Headline(false));
    }
}
