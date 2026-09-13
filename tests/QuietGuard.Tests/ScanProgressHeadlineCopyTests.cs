using QuietGuard;

namespace QuietGuard.Tests;

public class ScanProgressHeadlineCopyTests
{
    [Fact]
    public void Halfway_four_minute_typical_is_fifty()
    {
        var typical = TimeSpan.FromMinutes(4);
        Assert.Equal(50, ScanProgressHeadlineCopy.Percent(TimeSpan.FromMinutes(2), typical));
        Assert.Equal(
            ScanProgressCopy.Percent(TimeSpan.FromMinutes(2), typical),
            ScanProgressHeadlineCopy.Percent(TimeSpan.FromMinutes(2), typical));
        Assert.Equal(
            ScanProgressEstimate.Percent(TimeSpan.FromMinutes(2), typical),
            ScanProgressHeadlineCopy.Percent(TimeSpan.FromMinutes(2), typical));
    }

    [Fact]
    public void Complete_is_100_and_typical_is_three_minutes()
    {
        Assert.Equal(100, ScanProgressHeadlineCopy.Complete());
        Assert.Equal(ScanProgressCopy.Complete(), ScanProgressHeadlineCopy.Complete());
        Assert.Equal(ScanProgressEstimate.Complete(), ScanProgressHeadlineCopy.Complete());
        Assert.Equal(TimeSpan.FromMinutes(3), ScanProgressHeadlineCopy.TypicalQuickScan);
        Assert.Equal(ScanProgressCopy.TypicalQuickScan, ScanProgressHeadlineCopy.TypicalQuickScan);
        Assert.Equal(ScanProgressEstimate.TypicalQuickScan, ScanProgressHeadlineCopy.TypicalQuickScan);
    }
}
