namespace QuietGuard;

public static class LastScanOverdueCopy
{
    public static bool IsOverdue(DateTime? lastScanUtc, DateTime utcNow) =>
        LastScanDisplay.IsOverdue(lastScanUtc, utcNow, ScanScheduler.DefaultInterval);

    public static string Headline(DateTime? lastScanUtc, DateTime utcNow) =>
        IsOverdue(lastScanUtc, utcNow) ? "검사가 늦었습니다" : LastScanDisplay.Format(lastScanUtc, utcNow);
}
