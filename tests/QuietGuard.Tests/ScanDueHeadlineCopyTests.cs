using QuietGuard;

namespace QuietGuard.Tests;

public class ScanDueHeadlineCopyTests
{
    private static readonly DateTime UtcNow = new(2026, 9, 13, 12, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void Null_last_scan_is_due()
    {
        Assert.True(ScanDueHeadlineCopy.IsDue(null, UtcNow));
        Assert.Equal(ScanDueCopy.IsDue(null, UtcNow), ScanDueHeadlineCopy.IsDue(null, UtcNow));
        Assert.Equal(LastScanOverdueCopy.IsOverdue(null, UtcNow), ScanDueHeadlineCopy.IsDue(null, UtcNow));
        Assert.Equal("검사가 늦었습니다", ScanDueHeadlineCopy.Headline(null, UtcNow));
        Assert.Equal(ScanDueCopy.Headline(null, UtcNow), ScanDueHeadlineCopy.Headline(null, UtcNow));
        Assert.Equal(LastScanOverdueCopy.Headline(null, UtcNow), ScanDueHeadlineCopy.Headline(null, UtcNow));
    }

    [Fact]
    public void Recent_scan_is_not_due()
    {
        var last = UtcNow.AddHours(-6);
        Assert.False(ScanDueHeadlineCopy.IsDue(last, UtcNow));
        Assert.Equal(ScanDueCopy.IsDue(last, UtcNow), ScanDueHeadlineCopy.IsDue(last, UtcNow));
        Assert.Equal(ScanDueCopy.Headline(last, UtcNow), ScanDueHeadlineCopy.Headline(last, UtcNow));
        Assert.Equal(LastScanOverdueCopy.Headline(last, UtcNow), ScanDueHeadlineCopy.Headline(last, UtcNow));
    }
}
