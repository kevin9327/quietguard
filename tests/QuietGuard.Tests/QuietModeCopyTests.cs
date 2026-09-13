using QuietGuard;

namespace QuietGuard.Tests;

public class QuietModeCopyTests
{
    [Fact]
    public void Protected_suppresses_and_equals_quiet_mode()
    {
        Assert.True(QuietModeCopy.Suppress(ProtectionLevel.Protected));
        Assert.Equal(QuietMode.SuppressBalloons(ProtectionLevel.Protected), QuietModeCopy.Suppress(ProtectionLevel.Protected));
        Assert.Equal(!BalloonPolicy.Show(ProtectionLevel.Protected), QuietModeCopy.Suppress(ProtectionLevel.Protected));
    }

    [Fact]
    public void Unprotected_does_not_suppress()
    {
        Assert.False(QuietModeCopy.Suppress(ProtectionLevel.Unprotected));
    }

    [Fact]
    public void Protected_verdict_suppresses_and_equals_quiet_mode()
    {
        var verdict = new ProtectionVerdict(
            ProtectionLevel.Protected,
            "보호 중",
            Array.Empty<string>());

        Assert.True(QuietModeCopy.Suppress(verdict));
        Assert.Equal(QuietMode.SuppressBalloons(verdict), QuietModeCopy.Suppress(verdict));
    }

    [Fact]
    public void Attention_verdict_does_not_suppress()
    {
        var verdict = new ProtectionVerdict(
            ProtectionLevel.Attention,
            "조치 필요",
            Array.Empty<string>());

        Assert.False(QuietModeCopy.Suppress(verdict));
    }
}
