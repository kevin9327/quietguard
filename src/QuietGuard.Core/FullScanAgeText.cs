namespace QuietGuard;

public static class FullScanAgeText
{
    public static string Format(DateTime? lastFullScanUtc, DateTime utcNow)
    {
        if (lastFullScanUtc is not { } last)
            return "전체 검사 기록 없음";
        var age = utcNow - last.ToUniversalTime();
        if (age < TimeSpan.Zero)
            return "전체 검사 기록 없음";
        if (age.TotalDays < 1)
            return $"전체 검사 {(int)age.TotalHours}시간 전";
        return $"전체 검사 {(int)age.TotalDays}일 전";
    }

    public static bool IsOverdue(DateTime? lastFullScanUtc, DateTime utcNow, TimeSpan interval) =>
        LastScanDisplay.IsOverdue(lastFullScanUtc, utcNow, interval);
}
