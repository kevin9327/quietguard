namespace QuietGuard;

public static class ThreatLabelCopy
{
    public static string Button(ThreatActionKind kind) => ThreatActionLabels.Button(kind);

    public static string Restore() => ThreatActionLabels.Button(ThreatActionKind.Restore);

    public static string Allow() => ThreatActionLabels.Button(ThreatActionKind.Allow);

    public static string Remediate() => ThreatActionLabels.Button(ThreatActionKind.Remediate);
}
