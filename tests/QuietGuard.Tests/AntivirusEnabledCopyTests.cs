using QuietGuard;

namespace QuietGuard.Tests;

public class AntivirusEnabledCopyTests
{
    [Fact]
    public void Enabled_headline_is_on()
    {
        Assert.Equal("Microsoft Defender 백신 켜짐", AntivirusEnabledCopy.Headline(true));
        Assert.True(AntivirusEnabledCopy.IsQuiet(true));
    }

    [Fact]
    public void Disabled_headline_is_off()
    {
        Assert.Equal("Microsoft Defender 백신이 꺼져 있습니다", AntivirusEnabledCopy.Headline(false));
        Assert.False(AntivirusEnabledCopy.IsQuiet(false));
    }

    [Fact]
    public void DefenderStatus_overload_matches_bool_overload()
    {
        var on = Status(antivirusEnabled: true);
        var off = Status(antivirusEnabled: false);

        Assert.Equal(AntivirusEnabledCopy.Headline(true), AntivirusEnabledCopy.Headline(on));
        Assert.Equal(AntivirusEnabledCopy.IsQuiet(true), AntivirusEnabledCopy.IsQuiet(on));
        Assert.Equal(AntivirusEnabledCopy.Headline(false), AntivirusEnabledCopy.Headline(off));
        Assert.Equal(AntivirusEnabledCopy.IsQuiet(false), AntivirusEnabledCopy.IsQuiet(off));
    }

    private static DefenderStatus Status(bool antivirusEnabled) => new(
        AntivirusEnabled: antivirusEnabled,
        RealTimeProtectionEnabled: true,
        IoavProtectionEnabled: true,
        BehaviorMonitorEnabled: true,
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
