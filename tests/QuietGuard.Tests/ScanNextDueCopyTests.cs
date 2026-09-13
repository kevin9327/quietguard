using QuietGuard;

namespace QuietGuard.Tests;

public class ScanNextDueCopyTests
{
    private static readonly DateTime UtcNow = new(2026, 9, 13, 12, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void NextDueUtc_null_last_is_min_value()
    {
        Assert.Equal(DateTime.MinValue, ScanNextDueCopy.NextDueUtc(null, ScanScheduler.DefaultInterval));
        Assert.Equal(
            ScanScheduler.NextDueUtc(null, ScanScheduler.DefaultInterval),
            ScanNextDueCopy.NextDueUtc(null, ScanScheduler.DefaultInterval));
        Assert.Equal(
            ScanScheduler.NextDueUtc(null, ScanScheduler.DefaultInterval),
            ScanNextDueCopy.NextDueUtc(null));
    }

    [Fact]
    public void NextDueUtc_with_last_is_last_plus_interval()
    {
        var last = UtcNow;
        Assert.Equal(last + TimeSpan.FromHours(24), ScanNextDueCopy.NextDueUtc(last, ScanScheduler.DefaultInterval));
        Assert.Equal(
            ScanScheduler.NextDueUtc(last, ScanScheduler.DefaultInterval),
            ScanNextDueCopy.NextDueUtc(last, ScanScheduler.DefaultInterval));
        Assert.Equal(last + ScanScheduler.DefaultInterval, ScanNextDueCopy.NextDueUtc(last));
    }

    [Fact]
    public void Arguments_match_scheduled_quick_scan()
    {
        Assert.Equal("-Scan -ScanType 1", ScanNextDueCopy.Arguments());
        Assert.Equal(ScanScheduler.MpCmdArgumentsForScheduledQuickScan(), ScanNextDueCopy.Arguments());
        Assert.Equal(QuickScanCopy.Arguments(), ScanNextDueCopy.Arguments());
    }
}
