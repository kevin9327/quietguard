using QuietGuard;

namespace QuietGuard.Tests;

public class ScanElapsedHeadlineCopyTests
{
    [Fact]
    public void Zero_is_zero_seconds()
    {
        Assert.Equal("0초", ScanElapsedHeadlineCopy.Headline(TimeSpan.Zero));
        Assert.Equal(ScanElapsedCopy.Headline(TimeSpan.Zero), ScanElapsedHeadlineCopy.Headline(TimeSpan.Zero));
        Assert.Equal(ScanElapsedText.Format(TimeSpan.Zero), ScanElapsedHeadlineCopy.Headline(TimeSpan.Zero));
    }

    [Fact]
    public void Ninety_seconds_matches_copy_and_contains_minutes()
    {
        var elapsed = TimeSpan.FromSeconds(90);
        Assert.Equal(ScanElapsedCopy.Headline(elapsed), ScanElapsedHeadlineCopy.Headline(elapsed));
        Assert.Equal(ScanElapsedText.Format(elapsed), ScanElapsedHeadlineCopy.Headline(elapsed));
        Assert.Contains("분", ScanElapsedHeadlineCopy.Headline(elapsed));
        var typical = ScanProgressEstimate.TypicalQuickScan;
        Assert.Equal(
            ScanElapsedCopy.WithPercent(elapsed, typical),
            ScanElapsedHeadlineCopy.WithPercent(elapsed, typical));
        Assert.Equal(
            ScanElapsedText.WithPercent(elapsed, typical),
            ScanElapsedHeadlineCopy.WithPercent(elapsed, typical));
    }
}
