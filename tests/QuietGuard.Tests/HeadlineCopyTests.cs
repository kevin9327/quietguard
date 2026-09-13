using QuietGuard;

namespace QuietGuard.Tests;

public class HeadlineCopyTests
{
    [Fact]
    public void Healthy_equals_stack_and_starts_protected()
    {
        var status = Healthy();
        var lines = HeadlineCopy.From(status);
        Assert.Equal(HeadlineStack.From(status), lines);
        Assert.Equal(4, lines.Count);
        Assert.Equal(ProtectionAdvisor.Advise(status).Headline, lines[0]);
        Assert.Equal("보호 중", lines[0]);
    }

    [Fact]
    public void Realtime_off_headline_is_unprotected()
    {
        var status = Healthy() with { RealTimeProtectionEnabled = false };
        var lines = HeadlineCopy.From(status);
        Assert.Equal(HeadlineStack.From(status), lines);
        Assert.Equal(ProtectionAdvisor.Advise(status).Headline, lines[0]);
        Assert.Equal("보호되지 않음", lines[0]);
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
