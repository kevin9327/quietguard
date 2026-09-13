namespace QuietGuard;

public static class FullScanDueCopy
{
    public static bool IsDue(DateTime? lastFullScanUtc, DateTime utcNow) =>
        FullScanAgeText.IsOverdue(lastFullScanUtc, utcNow, ScanScheduler.DefaultInterval);

    public static string Headline(DateTime? lastFullScanUtc, DateTime utcNow) =>
        FullScanAgeText.Format(lastFullScanUtc, utcNow);
}
