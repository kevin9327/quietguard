namespace QuietGuard;

public static class ThreatAvailableCopy
{
    public static IReadOnlyList<ThreatActionKind> Available(ThreatInfo threat) =>
        ThreatListPresentation.AvailableActions(threat);
}
