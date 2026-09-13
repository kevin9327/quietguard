namespace QuietGuard;

public static class ThreatLabelHeadlineCopy
{
    public static string Button(ThreatActionKind kind) => ThreatLabelCopy.Button(kind);

    public static string Restore() => ThreatLabelCopy.Restore();

    public static string Allow() => ThreatLabelCopy.Allow();

    public static string Remediate() => ThreatLabelCopy.Remediate();
}
