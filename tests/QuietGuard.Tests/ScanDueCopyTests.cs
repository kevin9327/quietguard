using QuietGuard;

namespace QuietGuard.Tests;

public class ScanDueCopyTests
{
    private static readonly DateTime UtcNow = new(2026, 9, 13, 12, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void Null_last_scan_is_due()
    {
        Assert.Equal(
            LastScanOverdueCopy.IsOverdue(null, UtcNow),
            ScanDueCopy.IsDue(null, UtcNow));
        Assert.Equal(
            LastScanDisplay.IsOverdue(null, UtcNow, ScanScheduler.DefaultInterval),
            ScanDueCopy.IsDue(null, UtcNow));
        Assert.Equal(
            LastScanOverdueCopy.Headline(null, UtcNow),
            ScanDueCopy.Headline(null, UtcNow));
    }

    [Fact]
    public void Recent_scan_uses_last_scan_display()
    {
        var last = UtcNow - TimeSpan.FromHours(6);
        Assert.False(ScanDueCopy.IsDue(last, UtcNow));
        Assert.Equal(LastScanDisplay.Format(last, UtcNow), ScanDueCopy.Headline(last, UtcNow));
    }
}
