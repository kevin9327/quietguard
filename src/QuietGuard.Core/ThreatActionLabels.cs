namespace QuietGuard;

public static class ThreatActionLabels
{
    public static string Button(ThreatActionKind kind) => kind switch
    {
        ThreatActionKind.Restore => "복원",
        ThreatActionKind.Allow => "허용",
        ThreatActionKind.Remediate => "치료 검사",
        _ => kind.ToString()
    };
}
