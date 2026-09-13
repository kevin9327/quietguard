using QuietGuard;

namespace QuietGuard.Tests;

public class SignatureVersionCopyTests
{
    [Fact]
    public void Headline_version_equals_format()
    {
        Assert.Equal(
            SignatureVersionText.Format("1.459.188.0"),
            SignatureVersionCopy.Headline("1.459.188.0"));
        Assert.Equal("1.459.188.0", SignatureVersionCopy.Headline("1.459.188.0"));
    }

    [Fact]
    public void Headline_blank_is_none()
    {
        Assert.Equal("정의 버전 없음", SignatureVersionCopy.Headline(""));
        Assert.Equal("정의 버전 없음", SignatureVersionCopy.Headline("   "));
        Assert.Equal("정의 버전 없음", SignatureVersionCopy.Headline((string?)null));
        Assert.Equal(
            SignatureVersionText.Format(""),
            SignatureVersionCopy.Headline(""));
    }

    [Fact]
    public void DefenderStatus_overload_matches_format()
    {
        var status = Sample() with { SignatureVersion = "1.459.188.0" };
        var blank = Sample() with { SignatureVersion = "" };

        Assert.Equal(
            SignatureVersionText.Format(status),
            SignatureVersionCopy.Headline(status));
        Assert.Equal(
            SignatureVersionCopy.Headline("1.459.188.0"),
            SignatureVersionCopy.Headline(status));
        Assert.Equal(
            SignatureVersionText.Format(blank),
            SignatureVersionCopy.Headline(blank));
        Assert.Equal("정의 버전 없음", SignatureVersionCopy.Headline(blank));
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
