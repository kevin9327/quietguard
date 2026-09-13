namespace QuietGuard;

public static class ThreatCanActCopy
{
    public static bool CanAct(ThreatActionKind kind, ThreatInfo threat) =>
        ThreatActions.CanAct(kind, threat);

    public static bool CanRestore(ThreatInfo threat) =>
        ThreatActions.CanAct(ThreatActionKind.Restore, threat);
}
