using QuietGuard;

namespace QuietGuard.Tests;

public class HeadlineStackTests
{
    [Fact]
    public void Healthy_status_leads_with_protected_and_contains_realtime_on()
    {
        var headlines = HeadlineStack.From(Healthy());

        Assert.Equal("보호 중", headlines[0]);
        Assert.Contains(RealtimeProtectionCopy.Headline(true), headlines);
    }

    [Fact]
    public void Realtime_off_leads_with_shipped_advise_headline()
    {
        var status = Healthy() with { RealTimeProtectionEnabled = false };
        var headlines = HeadlineStack.From(status);

        Assert.Equal(ProtectionAdvisor.Advise(status).Headline, headlines[0]);
        Assert.Equal("보호되지 않음", headlines[0]);
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
