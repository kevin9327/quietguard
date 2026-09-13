using QuietGuard;

namespace QuietGuard.Tests;

public class EngineVersionCopyTests
{
    [Fact]
    public void Headline_version_equals_Format()
    {
        Assert.Equal("1.1.26080.3", EngineVersionCopy.Headline("1.1.26080.3"));
        Assert.Equal(
            EngineVersionText.Format("1.1.26080.3"),
            EngineVersionCopy.Headline("1.1.26080.3"));
    }

    [Fact]
    public void Headline_null_is_none()
    {
        Assert.Equal("엔진 버전 없음", EngineVersionCopy.Headline((string?)null));
        Assert.Equal(
            EngineVersionText.Format((string?)null),
            EngineVersionCopy.Headline((string?)null));
    }

    [Fact]
    public void DefenderStatus_overload_matches_Format()
    {
        AssertStatusMatchesFormat("1.1.26080.3");
        AssertStatusMatchesFormat(null);
        AssertStatusMatchesFormat("   ");
    }

    private static void AssertStatusMatchesFormat(string? version)
    {
        var status = Sample() with { EngineVersion = version };

        Assert.Equal(
            EngineVersionText.Format(status),
            EngineVersionCopy.Headline(status));
        Assert.Equal(
            EngineVersionCopy.Headline(version),
            EngineVersionCopy.Headline(status));
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
