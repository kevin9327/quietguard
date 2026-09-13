using QuietGuard;

namespace QuietGuard.Tests;

public class ScheduledScanCopyTests
{
    private static readonly DateTime UtcNow = new(2026, 9, 13, 12, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void Decide_matches_ScanScheduler_for_protected_due_scan()
    {
        var expected = ScanScheduler.Decide(UtcNow, null, ScanScheduler.DefaultInterval, ProtectionLevel.Protected);
        var actual = ScheduledScanCopy.Decide(UtcNow, null, ProtectionLevel.Protected);

        Assert.Equal(expected.ShouldScan, actual.ShouldScan);
        Assert.Equal(expected.NotifyUser, actual.NotifyUser);
        Assert.True(actual.ShouldScan);
        Assert.False(actual.NotifyUser);
        Assert.True(ScheduledScanCopy.Quiet(actual));
    }

    [Fact]
    public void Decide_unprotected_due_scan_notifies()
    {
        var expected = ScanScheduler.Decide(UtcNow, null, ScanScheduler.DefaultInterval, ProtectionLevel.Unprotected);
        var actual = ScheduledScanCopy.Decide(UtcNow, null, ProtectionLevel.Unprotected);

        Assert.Equal(expected.NotifyUser, actual.NotifyUser);
        Assert.True(actual.ShouldScan);
        Assert.True(actual.NotifyUser);
        Assert.False(ScheduledScanCopy.Quiet(actual));
    }

    [Fact]
    public void Arguments_match_quick_scan_and_scheduler()
    {
        Assert.Equal(QuickScanCopy.Arguments(), ScheduledScanCopy.Arguments());
        Assert.Equal(ScanScheduler.MpCmdArgumentsForScheduledQuickScan(), ScheduledScanCopy.Arguments());
    }
}
