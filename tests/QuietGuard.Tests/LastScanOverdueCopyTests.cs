using QuietGuard;

namespace QuietGuard.Tests;

public class LastScanOverdueCopyTests
{
    private static readonly DateTime UtcNow = new(2026, 9, 13, 12, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void Null_last_scan_is_overdue()
    {
        Assert.True(LastScanOverdueCopy.IsOverdue(null, UtcNow));
        Assert.Equal(
            LastScanDisplay.IsOverdue(null, UtcNow, ScanScheduler.DefaultInterval),
            LastScanOverdueCopy.IsOverdue(null, UtcNow));
        Assert.Equal("검사가 늦었습니다", LastScanOverdueCopy.Headline(null, UtcNow));
    }

    [Fact]
    public void Recent_scan_uses_last_scan_display()
    {
        var last = UtcNow - TimeSpan.FromHours(6);
        Assert.False(LastScanOverdueCopy.IsOverdue(last, UtcNow));
        Assert.Equal(LastScanDisplay.Format(last, UtcNow), LastScanOverdueCopy.Headline(last, UtcNow));
    }

    [Fact]
    public void Interval_elapsed_is_overdue()
    {
        var last = UtcNow - ScanScheduler.DefaultInterval;
        Assert.True(LastScanOverdueCopy.IsOverdue(last, UtcNow));
        Assert.Equal("검사가 늦었습니다", LastScanOverdueCopy.Headline(last, UtcNow));
    }
}
