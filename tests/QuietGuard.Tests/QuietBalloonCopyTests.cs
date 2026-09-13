using QuietGuard;

namespace QuietGuard.Tests;

public class QuietBalloonCopyTests
{
    [Fact]
    public void Protected_suppresses_and_headline_is_silent()
    {
        var verdict = ProtectionAdvisor.Advise(Healthy());
        var level = verdict.Level;

        Assert.Equal(ProtectionLevel.Protected, level);
        Assert.True(QuietBalloonCopy.Suppress(level));
        Assert.Equal(QuietMode.SuppressBalloons(level), QuietBalloonCopy.Suppress(level));
        Assert.Equal(!BalloonPolicy.Show(level), QuietBalloonCopy.Suppress(level));
        Assert.Equal("알림 없음", QuietBalloonCopy.Headline(level));
    }

    [Fact]
    public void Unprotected_does_not_suppress_and_headline_shows()
    {
        var status = Healthy() with { RealTimeProtectionEnabled = false };
        var verdict = ProtectionAdvisor.Advise(status);
        var level = verdict.Level;

        Assert.Equal(ProtectionLevel.Unprotected, level);
        Assert.False(QuietBalloonCopy.Suppress(level));
        Assert.Equal(QuietMode.SuppressBalloons(level), QuietBalloonCopy.Suppress(level));
        Assert.Equal(!BalloonPolicy.Show(level), QuietBalloonCopy.Suppress(level));
        Assert.Equal("알림 표시", QuietBalloonCopy.Headline(level));
    }

    private static DefenderStatus Healthy() => new(
        AntivirusEnabled: true,
        RealTimeProtectionEnabled: true,
        IoavProtectionEnabled: true,
        BehaviorMonitorEnabled: true,
        NisEnabled: true,
        IsTamperProtected: true,
        SignaturesOutOfDate: false,
        AntivirusSignatureLastUpdated: DateTime.Now.AddHours(-4),
        LastQuickScanTime: DateTime.Now.AddDays(-1),
        LastFullScanTime: DateTime.Now.AddDays(-7),
        EngineVersion: "1.1",
        SignatureVersion: "1.411",
        ProductStatus: "0");
}
