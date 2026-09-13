namespace QuietGuard;

public static class ScanNextDueCopy
{
    public static DateTime? NextDueUtc(DateTime? lastQuickScanUtc, TimeSpan interval) =>
        ScanScheduler.NextDueUtc(lastQuickScanUtc, interval);

    public static DateTime? NextDueUtc(DateTime? lastQuickScanUtc) =>
        ScanScheduler.NextDueUtc(lastQuickScanUtc, ScanScheduler.DefaultInterval);

    public static string Arguments() => ScanScheduler.MpCmdArgumentsForScheduledQuickScan();
}
