using QuietGuard;

namespace QuietGuard.Tests;

public class CloudHeadlineStackTests
{
    [Fact]
    public void Healthy_status_contains_cloud_and_ioav_on_headlines()
    {
        var headlines = CloudHeadlineStack.From(Healthy());

        Assert.Contains(CloudProtectionCopy.Headline(true, true), headlines);
        Assert.Contains(IoavProtectionCopy.Headline(true), headlines);
    }

    [Fact]
    public void Ioav_off_status_contains_ioav_off_headline()
    {
        var status = Healthy() with { IoavProtectionEnabled = false };
        var headlines = CloudHeadlineStack.From(status);

        Assert.Contains(IoavProtectionCopy.Headline(false), headlines);
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
