using QuietGuard;

namespace QuietGuard.Tests;

public class ServiceHeadlineCopyTests
{
    [Fact]
    public void Running_headline_equals_health_and_contains_service()
    {
        var headline = ServiceHeadlineCopy.Headline(true);
        Assert.Equal(ServiceHealthCopy.Headline(true), headline);
        Assert.Contains("WinDefend", headline);
        Assert.Contains("실행 중", headline);
    }

    [Fact]
    public void Stopped_headline_equals_health_and_contains_off()
    {
        var headline = ServiceHeadlineCopy.Headline(false);
        Assert.Equal(ServiceHealthCopy.Headline(false), headline);
        Assert.Contains("꺼져", headline);
    }

    [Fact]
    public void IsQuiet_matches_running_and_health()
    {
        Assert.True(ServiceHeadlineCopy.IsQuiet(true));
        Assert.False(ServiceHeadlineCopy.IsQuiet(false));
        Assert.Equal(ServiceHealthCopy.IsQuiet(true), ServiceHeadlineCopy.IsQuiet(true));
        Assert.Equal(ServiceHealthCopy.IsQuiet(false), ServiceHeadlineCopy.IsQuiet(false));
    }
}
