namespace QuietGuard;

public static class ThreatPlanCopy
{
    public static ThreatActionPlan Plan(ThreatActionKind kind, ThreatInfo threat) =>
        ThreatActions.Plan(kind, threat);

    public static string RestoreArguments(ThreatInfo threat) =>
        ThreatActions.Plan(ThreatActionKind.Restore, threat).Arguments;
}
