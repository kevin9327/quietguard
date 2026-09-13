using QuietGuard;

namespace QuietGuard.Tests;

public class TamperHeadlineCopyTests
{
    [Fact]
    public void Enabled_is_quiet_and_equals_tamper_quiet_copy()
    {
        Assert.True(TamperHeadlineCopy.IsQuiet(true));
        Assert.Equal(TamperQuietCopy.IsQuiet(true), TamperHeadlineCopy.IsQuiet(true));
        Assert.Equal(TamperProtectionCopy.IsQuiet(true), TamperHeadlineCopy.IsQuiet(true));
        Assert.Equal(TamperQuietCopy.Headline(true), TamperHeadlineCopy.Headline(true));
        Assert.Equal(TamperProtectionCopy.Headline(true), TamperHeadlineCopy.Headline(true));
    }

    [Fact]
    public void Disabled_is_not_quiet()
    {
        Assert.False(TamperHeadlineCopy.IsQuiet(false));
        Assert.Equal(TamperQuietCopy.IsQuiet(false), TamperHeadlineCopy.IsQuiet(false));
        Assert.Equal(TamperQuietCopy.Headline(false), TamperHeadlineCopy.Headline(false));
        Assert.Equal(TamperProtectionCopy.Headline(false), TamperHeadlineCopy.Headline(false));
    }
}
