using QuietGuard;

namespace QuietGuard.Tests;

public class LastScanCopyTests
{
    private static readonly DateTime UtcNow = new(2026, 9, 13, 12, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void Format_null_last_scan_is_none()
    {
        Assert.Equal("검사 기록 없음", LastScanCopy.Format(null, UtcNow));
        Assert.Equal(LastScanDisplay.Format(null, UtcNow), LastScanCopy.Format(null, UtcNow));
    }

    [Fact]
    public void Format_present_contains_last_scan_label()
    {
        var last = UtcNow.AddHours(-6);
        var text = LastScanCopy.Format(last, UtcNow);

        Assert.Contains("마지막 검사", text);
        Assert.Equal(LastScanDisplay.Format(last, UtcNow), text);
    }

    [Fact]
    public void IsOverdue_null_last_scan_is_overdue()
    {
        Assert.True(LastScanCopy.IsOverdue(null, UtcNow, ScanScheduler.DefaultInterval));
        Assert.Equal(
            LastScanDisplay.IsOverdue(null, UtcNow, ScanScheduler.DefaultInterval),
            LastScanCopy.IsOverdue(null, UtcNow, ScanScheduler.DefaultInterval));
    }

    [Fact]
    public void IsOverdue_interval_elapsed_is_overdue()
    {
        var last = UtcNow - ScanScheduler.DefaultInterval;
        Assert.True(LastScanCopy.IsOverdue(last, UtcNow, ScanScheduler.DefaultInterval));
        Assert.Equal(
            LastScanDisplay.IsOverdue(last, UtcNow, ScanScheduler.DefaultInterval),
            LastScanCopy.IsOverdue(last, UtcNow, ScanScheduler.DefaultInterval));
    }

    [Fact]
    public void IsOverdue_interval_not_elapsed_is_not_overdue()
    {
        var last = UtcNow - TimeSpan.FromHours(6);
        Assert.False(LastScanCopy.IsOverdue(last, UtcNow, ScanScheduler.DefaultInterval));
        Assert.Equal(
            LastScanDisplay.IsOverdue(last, UtcNow, ScanScheduler.DefaultInterval),
            LastScanCopy.IsOverdue(last, UtcNow, ScanScheduler.DefaultInterval));
    }
}
