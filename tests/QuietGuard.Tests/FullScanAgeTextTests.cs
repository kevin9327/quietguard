using QuietGuard;

namespace QuietGuard.Tests;

public class FullScanAgeTextTests
{
    private static readonly DateTime UtcNow = new(2026, 9, 13, 12, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void Null_last_scan_has_no_record()
    {
        Assert.Equal("전체 검사 기록 없음", FullScanAgeText.Format(null, UtcNow));
        Assert.True(FullScanAgeText.IsOverdue(null, UtcNow, ScanScheduler.DefaultInterval));
        Assert.True(LastScanDisplay.IsOverdue(null, UtcNow, ScanScheduler.DefaultInterval));
    }

    [Fact]
    public void Hours_and_days_buckets()
    {
        Assert.Equal("전체 검사 5시간 전", FullScanAgeText.Format(UtcNow.AddHours(-5), UtcNow));
        Assert.Equal("전체 검사 8일 전", FullScanAgeText.Format(UtcNow.AddDays(-8), UtcNow));
    }

    [Fact]
    public void Overdue_matches_LastScanDisplay()
    {
        var last = UtcNow - TimeSpan.FromHours(6);
        Assert.Equal(
            LastScanDisplay.IsOverdue(last, UtcNow, ScanScheduler.DefaultInterval),
            FullScanAgeText.IsOverdue(last, UtcNow, ScanScheduler.DefaultInterval));
        Assert.False(FullScanAgeText.IsOverdue(last, UtcNow, ScanScheduler.DefaultInterval));
    }
}
