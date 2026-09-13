namespace QuietGuard;

public static class ProtectionAdvisor
{
    public static readonly TimeSpan SignatureStaleAfter = TimeSpan.FromDays(3);

    public static ProtectionVerdict Advise(DefenderStatus status)
    {
        var reasons = new List<string>();

        if (!status.AntivirusEnabled)
            reasons.Add("Microsoft Defender 백신이 꺼져 있습니다.");

        if (!status.RealTimeProtectionEnabled)
            reasons.Add("실시간 보호가 꺼져 있습니다.");

        if (!status.IoavProtectionEnabled)
            reasons.Add("다운로드한 파일·첨부파일 검사가 꺼져 있습니다.");

        if (!status.IsTamperProtected)
            reasons.Add("변조 방지가 꺼져 있습니다.");

        if (status.SignaturesOutOfDate)
            reasons.Add("바이러스 정의가 오래되었습니다.");
        else if (SignatureAgeAdvisor.IsStale(status.SignatureAge, SignatureStaleAfter))
            reasons.Add($"바이러스 정의가 {SignatureAgeAdvisor.FormatAge(status.SignatureAge)}입니다.");

        if (reasons.Count == 0)
        {
            return new ProtectionVerdict(
                ProtectionLevel.Protected,
                "보호 중",
                ["실시간 보호와 최신 정의가 켜져 있습니다. 알림을 보내지 않습니다."]);
        }

        var level = !status.AntivirusEnabled || !status.RealTimeProtectionEnabled
            ? ProtectionLevel.Unprotected
            : ProtectionLevel.Attention;

        var headline = level == ProtectionLevel.Unprotected ? "보호되지 않음" : "조치 필요";
        return new ProtectionVerdict(level, headline, reasons);
    }
}
