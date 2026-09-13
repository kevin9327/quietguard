using QuietGuard;

namespace QuietGuard.Tests;

public class CloudHeadlineCopyTests
{
    [Fact]
    public void Healthy_from_equals_stack_four_headlines_starts_cloud()
    {
        var status = Healthy();
        var headlines = CloudHeadlineCopy.From(status);

        Assert.Equal(CloudHeadlineStack.From(status), headlines);
        Assert.Equal(4, headlines.Count);
        Assert.Equal(CloudProtectionCopy.Headline(status), headlines[0]);
    }

    [Fact]
    public void Ioav_off_second_headline_equals_stack()
    {
        var status = Healthy() with { IoavProtectionEnabled = false };
        var headlines = CloudHeadlineCopy.From(status);

        Assert.Equal(IoavProtectionCopy.Headline(status), headlines[1]);
        Assert.Equal(CloudHeadlineStack.From(status), headlines);
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
