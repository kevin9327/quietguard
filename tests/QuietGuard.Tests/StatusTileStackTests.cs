using QuietGuard;

namespace QuietGuard.Tests;

public class StatusTileStackTests
{
    [Fact]
    public void Healthy_all_true_uses_onoff_true_then_signature_format()
    {
        var status = Healthy();
        var tiles = StatusTileStack.From(status);

        Assert.Equal(4, tiles.Count);
        Assert.Equal(FirewallStatusText.OnOff(true), tiles[0]);
        Assert.Equal(FirewallStatusText.OnOff(true), tiles[1]);
        Assert.Equal(FirewallStatusText.OnOff(true), tiles[2]);
        Assert.Equal("켜짐", tiles[0]);
        Assert.Equal("켜짐", tiles[1]);
        Assert.Equal("켜짐", tiles[2]);
        Assert.Equal(SignatureVersionText.Format(status), tiles[3]);
        Assert.Equal("1.459.188.0", tiles[3]);
    }

    [Fact]
    public void Realtime_false_first_tile_is_off()
    {
        var status = Healthy() with { RealTimeProtectionEnabled = false };
        var tiles = StatusTileStack.From(status);

        Assert.Equal(FirewallStatusText.OnOff(false), tiles[0]);
        Assert.Equal("꺼짐", tiles[0]);
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
