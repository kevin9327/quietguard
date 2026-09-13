namespace QuietGuard;

public static class ThreatActionOrder
{
    public static IReadOnlyList<ThreatActionKind> Preferred =>
        [ThreatActionKind.Restore, ThreatActionKind.Allow, ThreatActionKind.Remediate];

    public static IReadOnlyList<ThreatActionKind> For(ThreatInfo threat) =>
        ThreatListPresentation.AvailableActions(threat);
}
