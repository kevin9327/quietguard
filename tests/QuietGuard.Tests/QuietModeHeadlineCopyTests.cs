using QuietGuard;

namespace QuietGuard.Tests;

public class QuietModeHeadlineCopyTests
{
    [Fact]
    public void Protected_suppresses()
    {
        Assert.True(QuietModeHeadlineCopy.Suppress(ProtectionLevel.Protected));
        Assert.Equal(QuietModeCopy.Suppress(ProtectionLevel.Protected), QuietModeHeadlineCopy.Suppress(ProtectionLevel.Protected));
        Assert.Equal(QuietMode.SuppressBalloons(ProtectionLevel.Protected), QuietModeHeadlineCopy.Suppress(ProtectionLevel.Protected));
    }

    [Fact]
    public void Unprotected_does_not_suppress()
    {
        Assert.False(QuietModeHeadlineCopy.Suppress(ProtectionLevel.Unprotected));
        Assert.Equal(QuietModeCopy.Suppress(ProtectionLevel.Unprotected), QuietModeHeadlineCopy.Suppress(ProtectionLevel.Unprotected));
        Assert.Equal(QuietMode.SuppressBalloons(ProtectionLevel.Unprotected), QuietModeHeadlineCopy.Suppress(ProtectionLevel.Unprotected));
    }
}
