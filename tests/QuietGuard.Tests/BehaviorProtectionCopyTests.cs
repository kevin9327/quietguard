using QuietGuard;

namespace QuietGuard.Tests;

public class BehaviorProtectionCopyTests
{
    [Fact]
    public void Enabled_headline_is_on()
    {
        Assert.Equal("동작 감시 켜짐", BehaviorProtectionCopy.Headline(true));
        Assert.True(BehaviorProtectionCopy.IsQuiet(true));
    }

    [Fact]
    public void Disabled_headline_is_off()
    {
        Assert.Equal("동작 감시가 꺼져 있습니다", BehaviorProtectionCopy.Headline(false));
        Assert.False(BehaviorProtectionCopy.IsQuiet(false));
    }

    [Fact]
    public void DefenderStatus_overload_matches_bool_overload()
    {
        var on = Status(behavior: true);
        var off = Status(behavior: false);

        Assert.Equal(BehaviorProtectionCopy.Headline(true), BehaviorProtectionCopy.Headline(on));
        Assert.Equal(BehaviorProtectionCopy.Headline(false), BehaviorProtectionCopy.Headline(off));
    }

    private static DefenderStatus Status(bool behavior) => new(
        AntivirusEnabled: true,
        RealTimeProtectionEnabled: true,
        IoavProtectionEnabled: true,
        BehaviorMonitorEnabled: behavior,
        NisEnabled: true,
        IsTamperProtected: true,
        SignaturesOutOfDate: false,
        AntivirusSignatureLastUpdated: DateTime.Now,
        LastQuickScanTime: DateTime.Now,
        LastFullScanTime: DateTime.Now,
        EngineVersion: "1",
        SignatureVersion: "1",
        ProductStatus: "0");
}
