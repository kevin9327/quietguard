using QuietGuard;

namespace QuietGuard.Tests;

public class NisProtectionCopyTests
{
    [Fact]
    public void Enabled_is_quiet()
    {
        Assert.True(NisProtectionCopy.IsQuiet(true));
        Assert.Equal("네트워크 검사 켜짐", NisProtectionCopy.Headline(true));
    }

    [Fact]
    public void Disabled_is_not_quiet()
    {
        Assert.False(NisProtectionCopy.IsQuiet(false));
        Assert.Contains("꺼져", NisProtectionCopy.Headline(false));
    }

    [Fact]
    public void DefenderStatus_overload_matches_bool_overload()
    {
        var on = Status(nis: true);
        var off = Status(nis: false);

        Assert.Equal(NisProtectionCopy.Headline(true), NisProtectionCopy.Headline(on));
        Assert.Equal(NisProtectionCopy.Headline(false), NisProtectionCopy.Headline(off));
        Assert.Equal(NisProtectionCopy.IsQuiet(true), NisProtectionCopy.IsQuiet(on));
        Assert.Equal(NisProtectionCopy.IsQuiet(false), NisProtectionCopy.IsQuiet(off));
    }

    private static DefenderStatus Status(bool nis) => new(
        AntivirusEnabled: true,
        RealTimeProtectionEnabled: true,
        IoavProtectionEnabled: true,
        BehaviorMonitorEnabled: true,
        NisEnabled: nis,
        IsTamperProtected: true,
        SignaturesOutOfDate: false,
        AntivirusSignatureLastUpdated: DateTime.Now,
        LastQuickScanTime: DateTime.Now,
        LastFullScanTime: DateTime.Now,
        EngineVersion: "1",
        SignatureVersion: "1",
        ProductStatus: "0");
}
