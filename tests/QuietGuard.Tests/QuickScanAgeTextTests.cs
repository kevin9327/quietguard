using QuietGuard;

namespace QuietGuard.Tests;

public class QuickScanAgeTextTests
{
    private static readonly DateTime UtcNow = new(2026, 9, 13, 12, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void Null_last_scan_has_no_record()
    {
        Assert.Equal("빠른 검사 기록 없음", QuickScanAgeText.Format(null, UtcNow));
        Assert.True(QuickScanAgeText.IsOverdue(null, UtcNow, ScanScheduler.DefaultInterval));
        Assert.True(LastScanDisplay.IsOverdue(null, UtcNow, ScanScheduler.DefaultInterval));
    }

    [Fact]
    public void Minutes_hours_days_buckets()
    {
        Assert.Contains("분 전", QuickScanAgeText.Format(UtcNow.AddMinutes(-20), UtcNow));
        Assert.Contains("시간 전", QuickScanAgeText.Format(UtcNow.AddHours(-5), UtcNow));
        Assert.Contains("일 전", QuickScanAgeText.Format(UtcNow.AddDays(-8), UtcNow));
    }

    [Fact]
    public void Overdue_matches_LastScanDisplay()
    {
        var last = UtcNow - TimeSpan.FromHours(6);
        Assert.Equal(
            LastScanDisplay.IsOverdue(last, UtcNow, ScanScheduler.DefaultInterval),
            QuickScanAgeText.IsOverdue(last, UtcNow, ScanScheduler.DefaultInterval));
        Assert.False(QuickScanAgeText.IsOverdue(last, UtcNow, ScanScheduler.DefaultInterval));
    }
}
