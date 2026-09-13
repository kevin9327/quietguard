using QuietGuard;

namespace QuietGuard.Tests;

public class LastScanHeadlineCopyTests
{
    private static readonly DateTime UtcNow = new(2026, 9, 13, 12, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void Null_is_none()
    {
        Assert.Equal("검사 기록 없음", LastScanHeadlineCopy.Format(null, UtcNow));
        Assert.Equal(LastScanCopy.Format(null, UtcNow), LastScanHeadlineCopy.Format(null, UtcNow));
        Assert.Equal(LastScanDisplay.Format(null, UtcNow), LastScanHeadlineCopy.Format(null, UtcNow));
    }

    [Fact]
    public void Present_contains_last_scan_label()
    {
        var last = UtcNow.AddHours(-6);
        Assert.Equal(LastScanCopy.Format(last, UtcNow), LastScanHeadlineCopy.Format(last, UtcNow));
        Assert.Equal(LastScanDisplay.Format(last, UtcNow), LastScanHeadlineCopy.Format(last, UtcNow));
        Assert.Contains("마지막 검사", LastScanHeadlineCopy.Format(last, UtcNow));
    }
}
