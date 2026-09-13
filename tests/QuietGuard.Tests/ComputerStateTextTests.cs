using QuietGuard;

namespace QuietGuard.Tests;

public class ComputerStateTextTests
{
    [Fact]
    public void Describe_null_is_none()
    {
        Assert.Equal("상태 없음", ComputerStateText.Describe((string?)null));
        AssertStringAndStatusOverloadsMatch(null);
    }

    [Fact]
    public void Describe_empty_is_none()
    {
        Assert.Equal("상태 없음", ComputerStateText.Describe(""));
        AssertStringAndStatusOverloadsMatch("");
    }

    [Fact]
    public void Describe_zero_string_is_healthy()
    {
        Assert.Equal("정상", ComputerStateText.Describe("0"));
        AssertStringAndStatusOverloadsMatch("0");
    }

    [Fact]
    public void Describe_numeric_zero_via_string_zero_is_healthy()
    {
        var zero = 0.ToString();

        Assert.Equal("0", zero);
        Assert.Equal("정상", ComputerStateText.Describe(zero));
        Assert.Equal("정상", ComputerStateText.Describe(Healthy() with { ProductStatus = zero }));
        AssertStringAndStatusOverloadsMatch(zero);
    }

    [Fact]
    public void Describe_nonzero_contains_raw_code()
    {
        var text = ComputerStateText.Describe("3");

        Assert.Contains("3", text);
        Assert.Equal("상태 코드 3", text);
        AssertStringAndStatusOverloadsMatch("3");
    }

    private static void AssertStringAndStatusOverloadsMatch(string? productStatus)
    {
        var status = Healthy() with { ProductStatus = productStatus };

        Assert.Equal(
            ComputerStateText.Describe(productStatus),
            ComputerStateText.Describe(status));
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
