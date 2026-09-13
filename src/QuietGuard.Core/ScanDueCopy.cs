namespace QuietGuard;

public static class ScanDueCopy
{
    public static bool IsDue(DateTime? lastScanUtc, DateTime utcNow) =>
        LastScanOverdueCopy.IsOverdue(lastScanUtc, utcNow);

    public static string Headline(DateTime? lastScanUtc, DateTime utcNow) =>
        LastScanOverdueCopy.Headline(lastScanUtc, utcNow);
}
