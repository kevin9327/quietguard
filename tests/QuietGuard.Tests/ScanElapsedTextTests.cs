using QuietGuard;

namespace QuietGuard.Tests;

public class ScanElapsedTextTests
{
    [Fact]
    public void Zero_is_zero_seconds()
    {
        Assert.Equal("0초", ScanElapsedText.Format(TimeSpan.Zero));
    }

    [Fact]
    public void Ninety_seconds_contains_minutes()
    {
        Assert.Contains("분", ScanElapsedText.Format(TimeSpan.FromSeconds(90)));
    }

    [Fact]
    public void Two_hours_contains_hours()
    {
        Assert.Contains("시간", ScanElapsedText.Format(TimeSpan.FromHours(2)));
    }

    [Fact]
    public void WithPercent_includes_elapsed_and_estimate()
    {
        var elapsed = TimeSpan.FromSeconds(90);
        var typical = ScanProgressEstimate.TypicalQuickScan;
        var text = ScanElapsedText.WithPercent(elapsed, typical);
        Assert.Contains(ScanElapsedText.Format(elapsed), text);
        Assert.Contains(ScanProgressEstimate.Percent(elapsed, typical).ToString(), text);
    }
}
