using QuietGuard;

namespace QuietGuard.Tests;

public class ScanProgressEstimateTests
{
    [Fact]
    public void Zero_or_negative_inputs_are_zero()
    {
        Assert.Equal(0, ScanProgressEstimate.Percent(TimeSpan.Zero, ScanProgressEstimate.TypicalQuickScan));
        Assert.Equal(0, ScanProgressEstimate.Percent(TimeSpan.FromSeconds(10), TimeSpan.Zero));
        Assert.Equal(0, ScanProgressEstimate.Percent(TimeSpan.FromSeconds(-1), TimeSpan.FromMinutes(3)));
    }

    [Fact]
    public void Halfway_is_about_fifty()
    {
        var typical = TimeSpan.FromMinutes(4);
        Assert.Equal(50, ScanProgressEstimate.Percent(TimeSpan.FromMinutes(2), typical));
    }

    [Fact]
    public void Past_typical_duration_caps_at_99_until_complete()
    {
        Assert.Equal(99, ScanProgressEstimate.Percent(TimeSpan.FromHours(2), TimeSpan.FromMinutes(3)));
        Assert.Equal(100, ScanProgressEstimate.Complete());
        Assert.NotEqual(ScanProgressEstimate.Complete(), ScanProgressEstimate.Percent(TimeSpan.FromHours(1), TimeSpan.FromMinutes(1)));
    }

    [Fact]
    public void Typical_quick_scan_is_positive()
    {
        Assert.True(ScanProgressEstimate.TypicalQuickScan > TimeSpan.Zero);
    }
}
