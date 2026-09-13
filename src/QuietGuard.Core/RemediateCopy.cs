namespace QuietGuard;

public static class RemediateCopy
{
    public static string Button() => ThreatActionLabels.Button(ThreatActionKind.Remediate);

    public static string Arguments(ThreatInfo threat) =>
        ThreatActions.Plan(ThreatActionKind.Remediate, threat).Arguments;
}
