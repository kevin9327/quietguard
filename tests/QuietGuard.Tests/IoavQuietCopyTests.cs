using QuietGuard;

namespace QuietGuard.Tests;

public class IoavQuietCopyTests
{
    [Fact]
    public void Enabled_matches_ioav_protection_copy()
    {
        Assert.Equal(IoavProtectionCopy.IsQuiet(true), IoavQuietCopy.IsQuiet(true));
        Assert.Equal(IoavProtectionCopy.Headline(true), IoavQuietCopy.Headline(true));
    }

    [Fact]
    public void Disabled_matches_ioav_protection_copy()
    {
        Assert.Equal(IoavProtectionCopy.IsQuiet(false), IoavQuietCopy.IsQuiet(false));
        Assert.Equal(IoavProtectionCopy.Headline(false), IoavQuietCopy.Headline(false));
    }
}
