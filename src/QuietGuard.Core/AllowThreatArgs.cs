namespace QuietGuard;

public static class AllowThreatArgs
{
    public static string For(ThreatInfo threat)
    {
        var plan = ThreatActions.Plan(ThreatActionKind.Allow, threat);
        return plan.Arguments;
    }
}
