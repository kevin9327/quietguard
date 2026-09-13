using QuietGuard;

namespace QuietGuard.Tests;

public class IoavProtectionCopyTests
{
    [Fact]
    public void Enabled_headline_is_on()
    {
        Assert.Equal("다운로드 파일 검사 켜짐", IoavProtectionCopy.Headline(true));
        Assert.True(IoavProtectionCopy.IsQuiet(true));
    }

    [Fact]
    public void Disabled_headline_is_off()
    {
        Assert.Equal("다운로드 파일 검사가 꺼져 있습니다", IoavProtectionCopy.Headline(false));
        Assert.False(IoavProtectionCopy.IsQuiet(false));
    }

    [Fact]
    public void DefenderStatus_overload_matches_bool_overload()
    {
        var on = Status(ioav: true);
        var off = Status(ioav: false);

        Assert.Equal(IoavProtectionCopy.Headline(true), IoavProtectionCopy.Headline(on));
        Assert.Equal(IoavProtectionCopy.Headline(false), IoavProtectionCopy.Headline(off));
    }

    private static DefenderStatus Status(bool ioav) => new(
        AntivirusEnabled: true,
        RealTimeProtectionEnabled: true,
        IoavProtectionEnabled: ioav,
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
