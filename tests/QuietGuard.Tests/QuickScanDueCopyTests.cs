using QuietGuard;

namespace QuietGuard.Tests;

public class QuickScanDueCopyTests
{
    private static readonly DateTime UtcNow = new(2026, 9, 13, 12, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void Null_last_scan_is_due()
    {
        Assert.Equal(
            QuickScanAgeText.IsOverdue(null, UtcNow, ScanScheduler.DefaultInterval),
            QuickScanDueCopy.IsDue(null, UtcNow));
        Assert.Equal(
            LastScanDisplay.IsOverdue(null, UtcNow, ScanScheduler.DefaultInterval),
            QuickScanDueCopy.IsDue(null, UtcNow));
        Assert.Equal(
            QuickScanAgeText.Format(null, UtcNow),
            QuickScanDueCopy.Headline(null, UtcNow));
    }

    [Fact]
    public void Recent_scan_uses_quick_scan_age_text()
    {
        var last = UtcNow - TimeSpan.FromHours(6);
        Assert.False(QuickScanDueCopy.IsDue(last, UtcNow));
        Assert.Equal(QuickScanAgeText.Format(last, UtcNow), QuickScanDueCopy.Headline(last, UtcNow));
    }
}
