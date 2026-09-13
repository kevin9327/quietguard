namespace QuietGuard;

public static class ThreatCountCopy
{
    public static string Format(int count) => ThreatCountText.Format(count);

    public static string Format(IReadOnlyCollection<ThreatInfo>? threats) =>
        ThreatCountText.Format(threats);
}
