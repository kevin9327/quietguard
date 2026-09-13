using QuietGuard;

namespace QuietGuard.Tests;

public class ProductEngineCopyTests
{
    [Fact]
    public void Name_matches_product_disclaimer_engine()
    {
        Assert.Equal(ProductDisclaimer.Engine, ProductEngineCopy.Name());
        Assert.Equal("Microsoft Defender", ProductEngineCopy.Name());
        Assert.True(ProductEngineCopy.IsDefender());
    }

    [Fact]
    public void Line_matches_self_test_banner()
    {
        Assert.Equal(SelfTestBanner.EngineLine(), ProductEngineCopy.Line());
        Assert.Contains(ProductDisclaimer.Engine, ProductEngineCopy.Line());
        Assert.StartsWith("engine-product=", ProductEngineCopy.Line());
    }
}
