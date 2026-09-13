using QuietGuard;

namespace QuietGuard.Tests;

public class ScheduledScanHeadlineCopyTests
{
    private static readonly DateTime UtcNow = new(2026, 9, 13, 12, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void Decide_protected_null_last_scan_is_quiet()
    {
        var expected = ScheduledScanCopy.Decide(UtcNow, null, ProtectionLevel.Protected);
        var actual = ScheduledScanHeadlineCopy.Decide(UtcNow, null, ProtectionLevel.Protected);

        Assert.Equal(expected.ShouldScan, actual.ShouldScan);
        Assert.Equal(expected.NotifyUser, actual.NotifyUser);
        Assert.True(actual.ShouldScan);
        Assert.False(actual.NotifyUser);
        Assert.True(ScheduledScanHeadlineCopy.Quiet(actual));
        Assert.Equal(ScheduledScanCopy.Quiet(actual), ScheduledScanHeadlineCopy.Quiet(actual));
    }

    [Fact]
    public void Decide_unprotected_null_last_scan_notifies()
    {
        var expected = ScheduledScanCopy.Decide(UtcNow, null, ProtectionLevel.Unprotected);
        var actual = ScheduledScanHeadlineCopy.Decide(UtcNow, null, ProtectionLevel.Unprotected);

        Assert.Equal(expected.NotifyUser, actual.NotifyUser);
        Assert.True(actual.NotifyUser);
        Assert.False(ScheduledScanHeadlineCopy.Quiet(actual));
        Assert.Equal(ScheduledScanCopy.Quiet(actual), ScheduledScanHeadlineCopy.Quiet(actual));
    }

    [Fact]
    public void Arguments_match_quick_scan_copy()
    {
        Assert.Equal(QuickScanCopy.Arguments(), ScheduledScanHeadlineCopy.Arguments());
        Assert.Equal(ScheduledScanCopy.Arguments(), ScheduledScanHeadlineCopy.Arguments());
    }
}
