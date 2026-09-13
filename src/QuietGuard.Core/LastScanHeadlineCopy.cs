namespace QuietGuard;

public static class LastScanHeadlineCopy
{
    public static string Format(DateTime? lastScanUtc, DateTime utcNow) =>
        LastScanCopy.Format(lastScanUtc, utcNow);
}
