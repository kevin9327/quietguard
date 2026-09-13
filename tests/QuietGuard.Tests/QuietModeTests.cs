using QuietGuard;

namespace QuietGuard.Tests;

public class QuietModeTests
{
    [Fact]
    public void Protected_verdict_suppresses_balloons()
    {
        var verdict = ProtectionAdvisor.Advise(Healthy());

        Assert.Equal(ProtectionLevel.Protected, verdict.Level);
        Assert.True(QuietMode.SuppressBalloons(verdict));
        Assert.True(QuietMode.SuppressBalloons(verdict.Level));
        Assert.False(BalloonPolicy.Show(verdict.Level));
    }

    [Fact]
    public void Unprotected_realtime_off_does_not_suppress_balloons()
    {
        var status = Healthy() with { RealTimeProtectionEnabled = false };
        var verdict = ProtectionAdvisor.Advise(status);

        Assert.Equal(ProtectionLevel.Unprotected, verdict.Level);
        Assert.False(QuietMode.SuppressBalloons(verdict));
        Assert.False(QuietMode.SuppressBalloons(verdict.Level));
        Assert.True(BalloonPolicy.Show(verdict.Level));
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
