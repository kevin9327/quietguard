using QuietGuard;

namespace QuietGuard.Tests;

public class ProtectionAdvisorTests
{
    [Fact]
    public void Healthy_status_is_quiet_protected()
    {
        var status = Healthy();
        var verdict = ProtectionAdvisor.Advise(status);

        Assert.Equal(ProtectionLevel.Protected, verdict.Level);
        Assert.Equal("보호 중", verdict.Headline);
        Assert.Contains(verdict.Reasons, r => r.Contains("알림을 보내지 않습니다"));
    }

    [Fact]
    public void Realtime_off_is_unprotected()
    {
        var status = Healthy() with { RealTimeProtectionEnabled = false };
        var verdict = ProtectionAdvisor.Advise(status);

        Assert.Equal(ProtectionLevel.Unprotected, verdict.Level);
        Assert.Equal("보호되지 않음", verdict.Headline);
        Assert.Contains(verdict.Reasons, r => r.Contains("실시간 보호"));
    }

    [Fact]
    public void Antivirus_off_is_unprotected()
    {
        var status = Healthy() with { AntivirusEnabled = false };
        var verdict = ProtectionAdvisor.Advise(status);

        Assert.Equal(ProtectionLevel.Unprotected, verdict.Level);
    }

    [Fact]
    public void Tamper_off_is_attention_not_unprotected()
    {
        var status = Healthy() with { IsTamperProtected = false };
        var verdict = ProtectionAdvisor.Advise(status);

        Assert.Equal(ProtectionLevel.Attention, verdict.Level);
        Assert.Equal("조치 필요", verdict.Headline);
        Assert.Contains(verdict.Reasons, r => r.Contains("변조 방지"));
    }

    [Fact]
    public void Stale_signatures_need_attention()
    {
        var status = Healthy() with
        {
            AntivirusSignatureLastUpdated = DateTime.Now.AddDays(-8)
        };
        var verdict = ProtectionAdvisor.Advise(status);

        Assert.Equal(ProtectionLevel.Attention, verdict.Level);
        Assert.Contains(verdict.Reasons, r => r.Contains("정의"));
    }

    [Fact]
    public void Out_of_date_flag_needs_attention()
    {
        var status = Healthy() with { SignaturesOutOfDate = true };
        var verdict = ProtectionAdvisor.Advise(status);

        Assert.Equal(ProtectionLevel.Attention, verdict.Level);
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
