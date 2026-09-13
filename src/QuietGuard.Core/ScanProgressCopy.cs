namespace QuietGuard;

public static class ScanProgressCopy
{
    public static int Percent(TimeSpan elapsed, TimeSpan typicalDuration) =>
        ScanProgressEstimate.Percent(elapsed, typicalDuration);

    public static int Complete() => ScanProgressEstimate.Complete();

    public static TimeSpan TypicalQuickScan => ScanProgressEstimate.TypicalQuickScan;
}
