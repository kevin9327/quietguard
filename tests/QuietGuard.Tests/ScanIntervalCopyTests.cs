using QuietGuard;

namespace QuietGuard.Tests;

public class ScanIntervalCopyTests
{
    [Fact]
    public void Default_equals_24_hours_and_ScanScheduler_DefaultInterval()
    {
        Assert.Equal(TimeSpan.FromHours(24), ScanIntervalCopy.Default);
        Assert.Equal(ScanScheduler.DefaultInterval, ScanIntervalCopy.Default);
    }

    [Fact]
    public void IsDefault_24h_is_true_and_1h_is_false()
    {
        Assert.True(ScanIntervalCopy.IsDefault(TimeSpan.FromHours(24)));
        Assert.False(ScanIntervalCopy.IsDefault(TimeSpan.FromHours(1)));
    }

    [Fact]
    public void IsDefault_equals_ScanScheduler_DefaultInterval()
    {
        Assert.True(ScanIntervalCopy.IsDefault(ScanScheduler.DefaultInterval));
        Assert.Equal(
            TimeSpan.FromHours(24) == ScanScheduler.DefaultInterval,
            ScanIntervalCopy.IsDefault(TimeSpan.FromHours(24)));
        Assert.Equal(
            TimeSpan.FromHours(1) == ScanScheduler.DefaultInterval,
            ScanIntervalCopy.IsDefault(TimeSpan.FromHours(1)));
    }
}
