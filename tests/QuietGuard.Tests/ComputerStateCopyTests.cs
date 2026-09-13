using QuietGuard;

namespace QuietGuard.Tests;

public class ComputerStateCopyTests
{
    [Fact]
    public void Headline_zero_equals_describe_healthy()
    {
        Assert.Equal("정상", ComputerStateCopy.Headline("0"));
        Assert.Equal(ComputerStateText.Describe("0"), ComputerStateCopy.Headline("0"));
    }

    [Fact]
    public void Headline_null_is_none()
    {
        Assert.Equal("상태 없음", ComputerStateCopy.Headline((string?)null));
        Assert.Equal(ComputerStateText.Describe((string?)null), ComputerStateCopy.Headline((string?)null));
    }

    [Fact]
    public void DefenderStatus_overload_matches_Describe()
    {
        var status = Healthy();

        Assert.Equal(ComputerStateText.Describe(status), ComputerStateCopy.Headline(status));
        Assert.Equal(ComputerStateText.Describe(status.ProductStatus), ComputerStateCopy.Headline(status));
        Assert.Equal(ComputerStateCopy.Headline(status.ProductStatus), ComputerStateCopy.Headline(status));
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
