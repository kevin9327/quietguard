using QuietGuard;

namespace QuietGuard.Tests;

public class ProtectionCopyTests
{
    [Fact]
    public void Healthy_is_protected_and_equals_advisor()
    {
        var status = Healthy();
        var expected = ProtectionAdvisor.Advise(status);
        var verdict = ProtectionCopy.Advise(status);
        Assert.Equal(expected.Level, verdict.Level);
        Assert.Equal(expected.Headline, verdict.Headline);
        Assert.Equal(expected.Reasons, verdict.Reasons);
        Assert.Equal(ProtectionLevel.Protected, verdict.Level);
        Assert.Equal("보호 중", verdict.Headline);
    }

    [Fact]
    public void Antivirus_off_is_unprotected()
    {
        var status = Healthy() with { AntivirusEnabled = false };
        var expected = ProtectionAdvisor.Advise(status);
        var verdict = ProtectionCopy.Advise(status);
        Assert.Equal(expected.Level, verdict.Level);
        Assert.Equal(expected.Headline, verdict.Headline);
        Assert.Equal(expected.Reasons, verdict.Reasons);
        Assert.Equal(ProtectionLevel.Unprotected, verdict.Level);
        Assert.Equal("보호되지 않음", verdict.Headline);
    }

    [Fact]
    public void SignatureStaleAfter_is_three_days()
    {
        Assert.Equal(TimeSpan.FromDays(3), ProtectionCopy.SignatureStaleAfter);
        Assert.Equal(ProtectionAdvisor.SignatureStaleAfter, ProtectionCopy.SignatureStaleAfter);
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
        SignatureVersion: "1.459.188.0",
        ProductStatus: "0");
}
