namespace QuietGuard;

public static class ElevationPlanCopy
{
    public static bool NeedsAdmin(ThreatActionPlan plan) =>
        ElevationPolicy.RequiresElevation(plan);

    public static bool NeedsAdmin(ThreatActionKind kind) =>
        ElevationPolicy.RequiresElevation(kind);
}
