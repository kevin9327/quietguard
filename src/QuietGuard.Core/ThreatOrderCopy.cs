namespace QuietGuard;

public static class ThreatOrderCopy
{
    public static IReadOnlyList<ThreatActionKind> Preferred => ThreatActionOrder.Preferred;

    public static IReadOnlyList<ThreatActionKind> For(ThreatInfo threat) =>
        ThreatActionOrder.For(threat);
}
