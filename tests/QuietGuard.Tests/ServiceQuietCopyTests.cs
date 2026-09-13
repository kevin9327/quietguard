using QuietGuard;

namespace QuietGuard.Tests;

public class ServiceQuietCopyTests
{
    [Fact]
    public void Running_matches_service_health_and_contains_service()
    {
        Assert.Equal(ServiceHealthCopy.IsQuiet(true), ServiceQuietCopy.IsQuiet(true));
        Assert.Equal(ServiceHealthCopy.Headline(true), ServiceQuietCopy.Headline(true));
        Assert.Contains(WinDefendNames.Service, ServiceQuietCopy.Headline(true));
    }

    [Fact]
    public void Stopped_matches_service_health()
    {
        Assert.Equal(ServiceHealthCopy.IsQuiet(false), ServiceQuietCopy.IsQuiet(false));
        Assert.Equal(ServiceHealthCopy.Headline(false), ServiceQuietCopy.Headline(false));
    }
}
