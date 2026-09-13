using QuietGuard;

namespace QuietGuard.Tests;

public class ServiceHealthCopyTests
{
    [Fact]
    public void Running_headline_contains_service_and_running()
    {
        var headline = ServiceHealthCopy.Headline(true);
        Assert.Contains(WinDefendNames.Service, headline);
        Assert.Contains("실행 중", headline);
        Assert.True(ServiceHealthCopy.IsQuiet(true));
    }

    [Fact]
    public void Stopped_headline_contains_off()
    {
        var headline = ServiceHealthCopy.Headline(false);
        Assert.Contains("꺼져", headline);
        Assert.False(ServiceHealthCopy.IsQuiet(false));
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void IsQuiet_matches_running(bool running)
    {
        Assert.Equal(running, ServiceHealthCopy.IsQuiet(running));
    }
}
