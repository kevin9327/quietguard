namespace QuietGuard;

public static class ScanDueHeadlineCopy
{
    public static bool IsDue(DateTime? lastScanUtc, DateTime utcNow) =>
        ScanDueCopy.IsDue(lastScanUtc, utcNow);

    public static string Headline(DateTime? lastScanUtc, DateTime utcNow) =>
        ScanDueCopy.Headline(lastScanUtc, utcNow);
}
