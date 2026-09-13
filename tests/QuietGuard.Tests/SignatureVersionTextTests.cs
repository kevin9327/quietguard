using QuietGuard;

namespace QuietGuard.Tests;

public class SignatureVersionTextTests
{
    [Fact]
    public void Format_null_is_none()
    {
        Assert.Equal("정의 버전 없음", SignatureVersionText.Format((string?)null));
        AssertStringAndStatusOverloadsMatch(null);
    }

    [Fact]
    public void Format_blank_is_none()
    {
        Assert.Equal("정의 버전 없음", SignatureVersionText.Format(""));
        Assert.Equal("정의 버전 없음", SignatureVersionText.Format("   "));
        AssertStringAndStatusOverloadsMatch("");
        AssertStringAndStatusOverloadsMatch("   ");
    }

    [Fact]
    public void Format_version_returns_that_string()
    {
        Assert.Equal("1.459.188.0", SignatureVersionText.Format("1.459.188.0"));
        AssertStringAndStatusOverloadsMatch("1.459.188.0");
    }

    [Fact]
    public void DefenderStatus_overload_matches_string_overload()
    {
        AssertStringAndStatusOverloadsMatch("1.459.188.0");
        AssertStringAndStatusOverloadsMatch(null);
        AssertStringAndStatusOverloadsMatch("   ");
    }

    private static void AssertStringAndStatusOverloadsMatch(string? version)
    {
        var status = Sample() with { SignatureVersion = version };

        Assert.Equal(
            SignatureVersionText.Format(version),
            SignatureVersionText.Format(status));
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
