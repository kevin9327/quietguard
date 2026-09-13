using QuietGuard;

namespace QuietGuard.Tests;

public class EngineVersionTextTests
{
    [Fact]
    public void Format_null_is_none()
    {
        Assert.Equal("엔진 버전 없음", EngineVersionText.Format((string?)null));
        AssertStringAndStatusOverloadsMatch(null);
    }

    [Fact]
    public void Format_blank_is_none()
    {
        Assert.Equal("엔진 버전 없음", EngineVersionText.Format(""));
        Assert.Equal("엔진 버전 없음", EngineVersionText.Format("   "));
        AssertStringAndStatusOverloadsMatch("");
        AssertStringAndStatusOverloadsMatch("   ");
    }

    [Fact]
    public void Format_version_returns_that_string()
    {
        Assert.Equal("1.1.26080.3", EngineVersionText.Format("1.1.26080.3"));
        AssertStringAndStatusOverloadsMatch("1.1.26080.3");
    }

    [Fact]
    public void DefenderStatus_overload_matches_string_overload()
    {
        AssertStringAndStatusOverloadsMatch("1.1.26080.3");
        AssertStringAndStatusOverloadsMatch(null);
        AssertStringAndStatusOverloadsMatch("   ");
    }

    private static void AssertStringAndStatusOverloadsMatch(string? version)
    {
        var status = Sample() with { EngineVersion = version };

        Assert.Equal(
            EngineVersionText.Format(version),
            EngineVersionText.Format(status));
    }

    private static DefenderStatus Sample() => new(
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
