namespace QuietGuard;

public static class LastScanOverdueHeadlineCopy
{
    public static bool IsOverdue(DateTime? lastScanUtc, DateTime utcNow) =>
        LastScanOverdueCopy.IsOverdue(lastScanUtc, utcNow);

    public static string Headline(DateTime? lastScanUtc, DateTime utcNow) =>
        LastScanOverdueCopy.Headline(lastScanUtc, utcNow);
}
