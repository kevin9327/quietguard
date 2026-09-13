using QuietGuard;

namespace QuietGuard.Tests;

public class ScanElapsedCopyTests
{
    [Fact]
    public void Zero_headline_matches_format_zero_seconds()
    {
        Assert.Equal("0초", ScanElapsedCopy.Headline(TimeSpan.Zero));
        Assert.Equal(ScanElapsedText.Format(TimeSpan.Zero), ScanElapsedCopy.Headline(TimeSpan.Zero));
    }

    [Fact]
    public void Ninety_seconds_headline_matches_format_and_contains_minutes()
    {
        var elapsed = TimeSpan.FromSeconds(90);
        Assert.Equal(ScanElapsedText.Format(elapsed), ScanElapsedCopy.Headline(elapsed));
        Assert.Contains("분", ScanElapsedCopy.Headline(elapsed));
    }

    [Fact]
    public void WithPercent_matches_scan_elapsed_text_using_typical_quick_scan()
    {
        var elapsed = TimeSpan.FromSeconds(90);
        var typical = ScanProgressEstimate.TypicalQuickScan;
        Assert.Equal(
            ScanElapsedText.WithPercent(elapsed, typical),
            ScanElapsedCopy.WithPercent(elapsed, typical));
    }
}
