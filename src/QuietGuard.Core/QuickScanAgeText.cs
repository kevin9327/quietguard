namespace QuietGuard;

public static class QuickScanAgeText
{
    public static string Format(DateTime? lastQuickScanUtc, DateTime utcNow)
    {
        if (lastQuickScanUtc is not { } last)
            return "빠른 검사 기록 없음";
        var age = utcNow - last.ToUniversalTime();
        if (age < TimeSpan.Zero)
            return "빠른 검사 기록 없음";
        if (age.TotalHours < 1)
            return $"빠른 검사 {Math.Max(0, (int)age.TotalMinutes)}분 전";
        if (age.TotalDays < 1)
            return $"빠른 검사 {(int)age.TotalHours}시간 전";
        return $"빠른 검사 {(int)age.TotalDays}일 전";
    }

    public static bool IsOverdue(DateTime? lastQuickScanUtc, DateTime utcNow, TimeSpan interval) =>
        LastScanDisplay.IsOverdue(lastQuickScanUtc, utcNow, interval);
}
