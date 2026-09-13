using QuietGuard;

namespace QuietGuard.Tests;

public class RealtimeProtectionCopyTests
{
    [Fact]
    public void Enabled_headline_is_on()
    {
        Assert.Equal("실시간 보호 켜짐", RealtimeProtectionCopy.Headline(true));
        Assert.True(RealtimeProtectionCopy.IsQuiet(true));
    }

    [Fact]
    public void Disabled_headline_is_off()
    {
        Assert.Equal("실시간 보호가 꺼져 있습니다", RealtimeProtectionCopy.Headline(false));
        Assert.False(RealtimeProtectionCopy.IsQuiet(false));
    }

    [Fact]
    public void DefenderStatus_overload_matches_bool_overload()
    {
        var on = Healthy();
        var off = Healthy() with { RealTimeProtectionEnabled = false };

        Assert.Equal(RealtimeProtectionCopy.Headline(true), RealtimeProtectionCopy.Headline(on));
        Assert.Equal(RealtimeProtectionCopy.IsQuiet(true), RealtimeProtectionCopy.IsQuiet(on));
        Assert.Equal(RealtimeProtectionCopy.Headline(false), RealtimeProtectionCopy.Headline(off));
        Assert.Equal(RealtimeProtectionCopy.IsQuiet(false), RealtimeProtectionCopy.IsQuiet(off));
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
