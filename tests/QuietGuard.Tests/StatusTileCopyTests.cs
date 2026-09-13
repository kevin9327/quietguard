using QuietGuard;

namespace QuietGuard.Tests;

public class StatusTileCopyTests
{
    [Fact]
    public void Healthy_from_equals_stack_four_tiles_on_then_signature()
    {
        var status = Healthy();
        var tiles = StatusTileCopy.From(status);

        Assert.Equal(StatusTileStack.From(status), tiles);
        Assert.Equal(4, tiles.Count);
        Assert.Equal("켜짐", tiles[0]);
        Assert.Equal("켜짐", tiles[1]);
        Assert.Equal("켜짐", tiles[2]);
        Assert.Equal(SignatureVersionText.Format(status), tiles[3]);
        Assert.Equal("1.459.188.0", tiles[3]);
    }

    [Fact]
    public void Realtime_false_first_tile_off_equals_stack()
    {
        var status = Healthy() with { RealTimeProtectionEnabled = false };
        var tiles = StatusTileCopy.From(status);

        Assert.Equal("꺼짐", tiles[0]);
        Assert.Equal(StatusTileStack.From(status), tiles);
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
