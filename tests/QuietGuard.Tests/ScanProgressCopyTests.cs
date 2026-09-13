using QuietGuard;

namespace QuietGuard.Tests;

public class ScanProgressCopyTests
{
    [Fact]
    public void Zero_elapsed_is_zero_and_equals_estimate()
    {
        Assert.Equal(0, ScanProgressCopy.Percent(TimeSpan.Zero, ScanProgressCopy.TypicalQuickScan));
        Assert.Equal(
            ScanProgressEstimate.Percent(TimeSpan.Zero, ScanProgressEstimate.TypicalQuickScan),
            ScanProgressCopy.Percent(TimeSpan.Zero, ScanProgressCopy.TypicalQuickScan));
    }

    [Fact]
    public void Halfway_four_minute_typical_is_fifty()
    {
        var typical = TimeSpan.FromMinutes(4);
        Assert.Equal(50, ScanProgressCopy.Percent(TimeSpan.FromMinutes(2), typical));
        Assert.Equal(
            ScanProgressEstimate.Percent(TimeSpan.FromMinutes(2), typical),
            ScanProgressCopy.Percent(TimeSpan.FromMinutes(2), typical));
    }

    [Fact]
    public void Complete_is_100_and_past_typical_caps_at_99()
    {
        Assert.Equal(100, ScanProgressCopy.Complete());
        Assert.Equal(ScanProgressEstimate.Complete(), ScanProgressCopy.Complete());
        Assert.Equal(99, ScanProgressCopy.Percent(TimeSpan.FromHours(2), TimeSpan.FromMinutes(3)));
        Assert.Equal(
            ScanProgressEstimate.Percent(TimeSpan.FromHours(2), TimeSpan.FromMinutes(3)),
            ScanProgressCopy.Percent(TimeSpan.FromHours(2), TimeSpan.FromMinutes(3)));
    }

    [Fact]
    public void TypicalQuickScan_equals_three_minutes_and_estimate()
    {
        Assert.Equal(TimeSpan.FromMinutes(3), ScanProgressCopy.TypicalQuickScan);
        Assert.Equal(ScanProgressEstimate.TypicalQuickScan, ScanProgressCopy.TypicalQuickScan);
    }
}
