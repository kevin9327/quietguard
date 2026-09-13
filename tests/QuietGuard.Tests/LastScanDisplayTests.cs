using QuietGuard;

namespace QuietGuard.Tests;

public class LastScanDisplayTests
{
    private static readonly DateTime UtcNow = new(2026, 9, 13, 12, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void Format_null_last_scan_is_none()
    {
        Assert.Equal("검사 기록 없음", LastScanDisplay.Format(null, UtcNow));
    }

    [Fact]
    public void Format_present_contains_last_scan_label_and_local_time()
    {
        var last = UtcNow.AddHours(-6);
        var text = LastScanDisplay.Format(last, UtcNow);

        Assert.Contains("마지막 검사", text);
        Assert.Equal($"마지막 검사 {last.ToLocalTime():MM-dd HH:mm}", text);
    }

    [Fact]
    public void IsOverdue_null_last_scan_is_overdue()
    {
        Assert.True(LastScanDisplay.IsOverdue(null, UtcNow, ScanScheduler.DefaultInterval));
    }

    [Fact]
    public void IsOverdue_interval_elapsed_is_overdue()
    {
        var last = UtcNow - ScanScheduler.DefaultInterval;
        Assert.True(LastScanDisplay.IsOverdue(last, UtcNow, ScanScheduler.DefaultInterval));
    }

    [Fact]
    public void IsOverdue_interval_not_elapsed_is_not_overdue()
    {
        var last = UtcNow - TimeSpan.FromHours(6);
        Assert.False(LastScanDisplay.IsOverdue(last, UtcNow, ScanScheduler.DefaultInterval));
    }
}
