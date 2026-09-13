namespace QuietGuard;

public static class LastScanDisplay
{
    public static string Format(DateTime? lastScanUtc, DateTime utcNow)
    {
        if (lastScanUtc is not { } last)
            return "검사 기록 없음";
        return $"마지막 검사 {last.ToLocalTime():MM-dd HH:mm}";
    }

    public static bool IsOverdue(DateTime? lastScanUtc, DateTime utcNow, TimeSpan interval)
    {
        if (lastScanUtc is not { } last)
            return true;
        return utcNow - last >= interval;
    }
}
