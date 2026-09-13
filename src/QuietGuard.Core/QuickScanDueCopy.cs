namespace QuietGuard;

public static class QuickScanDueCopy
{
    public static bool IsDue(DateTime? lastQuickScanUtc, DateTime utcNow) =>
        QuickScanAgeText.IsOverdue(lastQuickScanUtc, utcNow, ScanScheduler.DefaultInterval);

    public static string Headline(DateTime? lastQuickScanUtc, DateTime utcNow) =>
        QuickScanAgeText.Format(lastQuickScanUtc, utcNow);
}
