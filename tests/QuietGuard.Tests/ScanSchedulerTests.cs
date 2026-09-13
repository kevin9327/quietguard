using QuietGuard;

namespace QuietGuard.Tests;

public class ScanSchedulerTests
{
    private static readonly DateTime UtcNow = new(2026, 9, 13, 12, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void Interval_not_elapsed_does_not_scan_or_notify()
    {
        var last = UtcNow - TimeSpan.FromHours(6);
        var decision = ScanScheduler.Decide(UtcNow, last, ScanScheduler.DefaultInterval, ProtectionLevel.Unprotected);

        Assert.False(decision.ShouldScan);
        Assert.False(decision.NotifyUser);
        Assert.Contains("대기", decision.Reason);
    }

    [Fact]
    public void Interval_elapsed_protected_scans_quietly()
    {
        var last = UtcNow - ScanScheduler.DefaultInterval;
        var decision = ScanScheduler.Decide(UtcNow, last, ScanScheduler.DefaultInterval, ProtectionLevel.Protected);

        Assert.True(decision.ShouldScan);
        Assert.False(decision.NotifyUser);
        Assert.Contains("조용", decision.Reason);
    }

    [Fact]
    public void Interval_elapsed_unprotected_scans_and_notifies()
    {
        var last = UtcNow - ScanScheduler.DefaultInterval;
        var decision = ScanScheduler.Decide(UtcNow, last, ScanScheduler.DefaultInterval, ProtectionLevel.Unprotected);

        Assert.True(decision.ShouldScan);
        Assert.True(decision.NotifyUser);
        Assert.Contains("알림", decision.Reason);
    }

    [Fact]
    public void Null_last_scan_protected_scans_quietly()
    {
        var decision = ScanScheduler.Decide(UtcNow, null, ScanScheduler.DefaultInterval, ProtectionLevel.Protected);

        Assert.True(decision.ShouldScan);
        Assert.False(decision.NotifyUser);
        Assert.Contains("조용", decision.Reason);
    }

    [Fact]
    public void NextDueUtc_null_last_is_min_value()
    {
        Assert.Equal(DateTime.MinValue, ScanScheduler.NextDueUtc(null, ScanScheduler.DefaultInterval));
    }

    [Fact]
    public void NextDueUtc_with_last_is_last_plus_interval()
    {
        var last = UtcNow.AddDays(-1);
        Assert.Equal(last + ScanScheduler.DefaultInterval, ScanScheduler.NextDueUtc(last, ScanScheduler.DefaultInterval));
    }

    [Fact]
    public void MpCmd_arguments_are_scheduled_quick_scan()
    {
        var args = ScanScheduler.MpCmdArgumentsForScheduledQuickScan();
        Assert.Contains("-Scan", args);
        Assert.Contains("-ScanType 1", args);
    }
}
