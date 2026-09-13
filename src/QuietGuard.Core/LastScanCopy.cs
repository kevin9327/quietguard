namespace QuietGuard;

public static class LastScanCopy
{
    public static string Format(DateTime? lastScanUtc, DateTime utcNow) =>
        LastScanDisplay.Format(lastScanUtc, utcNow);

    public static bool IsOverdue(DateTime? lastScanUtc, DateTime utcNow, TimeSpan interval) =>
        LastScanDisplay.IsOverdue(lastScanUtc, utcNow, interval);
}
