using QuietGuard;

namespace QuietGuard.Tests;

public class LastScanOverdueHeadlineCopyTests
{
    private static readonly DateTime UtcNow = new(2026, 9, 13, 12, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void Null_last_scan_is_overdue()
    {
        Assert.True(LastScanOverdueHeadlineCopy.IsOverdue(null, UtcNow));
        Assert.Equal(
            LastScanOverdueCopy.IsOverdue(null, UtcNow),
            LastScanOverdueHeadlineCopy.IsOverdue(null, UtcNow));
        Assert.Equal("검사가 늦었습니다", LastScanOverdueHeadlineCopy.Headline(null, UtcNow));
        Assert.Equal(
            LastScanOverdueCopy.Headline(null, UtcNow),
            LastScanOverdueHeadlineCopy.Headline(null, UtcNow));
    }

    [Fact]
    public void Recent_scan_uses_last_scan_display()
    {
        var last = UtcNow - TimeSpan.FromHours(6);
        Assert.False(LastScanOverdueHeadlineCopy.IsOverdue(last, UtcNow));
        Assert.Equal(
            LastScanOverdueCopy.IsOverdue(last, UtcNow),
            LastScanOverdueHeadlineCopy.IsOverdue(last, UtcNow));
        Assert.Equal(LastScanDisplay.Format(last, UtcNow), LastScanOverdueHeadlineCopy.Headline(last, UtcNow));
        Assert.Equal(
            LastScanOverdueCopy.Headline(last, UtcNow),
            LastScanOverdueHeadlineCopy.Headline(last, UtcNow));
    }
}
