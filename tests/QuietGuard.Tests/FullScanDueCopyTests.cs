using QuietGuard;

namespace QuietGuard.Tests;

public class FullScanDueCopyTests
{
    private static readonly DateTime UtcNow = new(2026, 9, 13, 12, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void Null_last_scan_is_due()
    {
        Assert.Equal(
            FullScanAgeText.IsOverdue(null, UtcNow, ScanScheduler.DefaultInterval),
            FullScanDueCopy.IsDue(null, UtcNow));
        Assert.Equal(
            LastScanDisplay.IsOverdue(null, UtcNow, ScanScheduler.DefaultInterval),
            FullScanDueCopy.IsDue(null, UtcNow));
        Assert.Equal(
            FullScanAgeText.Format(null, UtcNow),
            FullScanDueCopy.Headline(null, UtcNow));
    }

    [Fact]
    public void Recent_scan_uses_full_scan_age_text()
    {
        var last = UtcNow - TimeSpan.FromHours(6);
        Assert.False(FullScanDueCopy.IsDue(last, UtcNow));
        Assert.Equal(FullScanAgeText.Format(last, UtcNow), FullScanDueCopy.Headline(last, UtcNow));
    }
}
