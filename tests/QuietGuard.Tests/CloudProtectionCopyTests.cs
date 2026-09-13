using QuietGuard;

namespace QuietGuard.Tests;

public class CloudProtectionCopyTests
{
    [Fact]
    public void Both_on_is_quiet()
    {
        Assert.True(CloudProtectionCopy.IsQuiet(true, true));
        Assert.Equal("클라우드·동작 감시 켜짐", CloudProtectionCopy.Headline(true, true));
    }

    [Fact]
    public void Both_off_is_not_quiet()
    {
        Assert.False(CloudProtectionCopy.IsQuiet(false, false));
        Assert.Equal("클라우드·동작 감시 꺼짐", CloudProtectionCopy.Headline(false, false));
    }

    [Fact]
    public void Ioav_off_mentions_download_scan()
    {
        Assert.False(CloudProtectionCopy.IsQuiet(false, true));
        Assert.Contains("다운로드", CloudProtectionCopy.Headline(false, true));
    }

    [Fact]
    public void Behavior_off_mentions_behavior()
    {
        Assert.False(CloudProtectionCopy.IsQuiet(true, false));
        Assert.Contains("동작 감시", CloudProtectionCopy.Headline(true, false));
    }

    [Fact]
    public void DefenderStatus_overload_matches_bool_overload()
    {
        var status = new DefenderStatus(
            AntivirusEnabled: true,
            RealTimeProtectionEnabled: true,
            IoavProtectionEnabled: true,
            BehaviorMonitorEnabled: false,
            NisEnabled: true,
            IsTamperProtected: true,
            SignaturesOutOfDate: false,
            AntivirusSignatureLastUpdated: DateTime.Now,
            LastQuickScanTime: DateTime.Now,
            LastFullScanTime: DateTime.Now,
            EngineVersion: "1",
            SignatureVersion: "1",
            ProductStatus: "0");

        Assert.Equal(
            CloudProtectionCopy.Headline(true, false),
            CloudProtectionCopy.Headline(status));
    }
}
