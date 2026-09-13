namespace QuietGuard;

public static class ThreatCountText
{
    public static string Format(int count)
    {
        if (count < 0) count = 0;
        if (count == 0) return "최근 위협 없음";
        return $"최근 위협 {count}건";
    }

    public static string Format(IReadOnlyCollection<ThreatInfo>? threats) =>
        Format(threats?.Count ?? 0);
}
