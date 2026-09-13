namespace QuietGuard;

public static class ScanProgressHeadlineCopy
{
    public static int Percent(TimeSpan elapsed, TimeSpan typicalDuration) =>
        ScanProgressCopy.Percent(elapsed, typicalDuration);

    public static int Complete() => ScanProgressCopy.Complete();

    public static TimeSpan TypicalQuickScan => ScanProgressCopy.TypicalQuickScan;
}
