using QuietGuard;

namespace QuietGuard.Tests;

public class QuietBalloonHeadlineCopyTests
{
    [Fact]
    public void Protected_suppresses_and_headline_is_silent()
    {
        Assert.True(QuietBalloonHeadlineCopy.Suppress(ProtectionLevel.Protected));
        Assert.Equal(
            QuietBalloonCopy.Suppress(ProtectionLevel.Protected),
            QuietBalloonHeadlineCopy.Suppress(ProtectionLevel.Protected));
        Assert.Equal(
            QuietMode.SuppressBalloons(ProtectionLevel.Protected),
            QuietBalloonHeadlineCopy.Suppress(ProtectionLevel.Protected));
        Assert.Equal("알림 없음", QuietBalloonHeadlineCopy.Headline(ProtectionLevel.Protected));
        Assert.Equal(
            QuietBalloonCopy.Headline(ProtectionLevel.Protected),
            QuietBalloonHeadlineCopy.Headline(ProtectionLevel.Protected));
    }

    [Fact]
    public void Unprotected_does_not_suppress_and_headline_shows()
    {
        Assert.False(QuietBalloonHeadlineCopy.Suppress(ProtectionLevel.Unprotected));
        Assert.Equal(
            QuietBalloonCopy.Suppress(ProtectionLevel.Unprotected),
            QuietBalloonHeadlineCopy.Suppress(ProtectionLevel.Unprotected));
        Assert.Equal(
            QuietMode.SuppressBalloons(ProtectionLevel.Unprotected),
            QuietBalloonHeadlineCopy.Suppress(ProtectionLevel.Unprotected));
        Assert.Equal("알림 표시", QuietBalloonHeadlineCopy.Headline(ProtectionLevel.Unprotected));
        Assert.Equal(
            QuietBalloonCopy.Headline(ProtectionLevel.Unprotected),
            QuietBalloonHeadlineCopy.Headline(ProtectionLevel.Unprotected));
    }
}
