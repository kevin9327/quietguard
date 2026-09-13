using QuietGuard;

namespace QuietGuard.Tests;

public class ProductDisclaimerTests
{
    [Fact]
    public void Engine_is_microsoft_defender()
    {
        Assert.Equal("Microsoft Defender", ProductDisclaimer.Engine);
    }

    [Fact]
    public void Footer_contains_engine_no_ads_and_not_ahnlab()
    {
        var footer = ProductDisclaimer.Footer();

        Assert.Contains("Microsoft Defender", footer);
        Assert.Contains("광고 없음", footer);
        Assert.Contains(ProductDisclaimer.NotAhnLab, footer);
    }
}
