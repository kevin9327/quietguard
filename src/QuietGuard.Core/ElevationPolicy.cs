namespace QuietGuard;

public static class ElevationPolicy
{
    // Restore and Allow require elevation; Remediate does not.
    // Must call ThreatActions.Plan on a path-bearing ThreatInfo and return plan.RequiresElevation.
    // Also expose a kind-only helper that matches that contract without needing a live plan for empty threats:
    public static bool RequiresElevation(ThreatActionKind kind) =>
        kind is ThreatActionKind.Restore or ThreatActionKind.Allow;

    public static bool RequiresElevation(ThreatActionPlan plan) => plan.RequiresElevation;
}
