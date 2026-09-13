namespace QuietGuard;

public static class ThreatSummaryCopy
{
    public static string Summary(ThreatActionKind kind, ThreatInfo threat) =>
        ThreatActions.Plan(kind, threat).Summary;

    public static bool NotifyUser(ThreatActionKind kind, ThreatInfo threat) =>
        ThreatActions.Plan(kind, threat).NotifyUser;
}
