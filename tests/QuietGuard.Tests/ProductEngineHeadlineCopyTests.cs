using QuietGuard;

namespace QuietGuard.Tests;

public class ProductEngineHeadlineCopyTests
{
    [Fact]
    public void Name_matches_product_engine_copy_and_disclaimer()
    {
        Assert.Equal(ProductDisclaimer.Engine, ProductEngineHeadlineCopy.Name());
        Assert.Equal(ProductEngineCopy.Name(), ProductEngineHeadlineCopy.Name());
        Assert.Equal("Microsoft Defender", ProductEngineHeadlineCopy.Name());
        Assert.True(ProductEngineHeadlineCopy.IsDefender());
        Assert.Equal(ProductEngineCopy.IsDefender(), ProductEngineHeadlineCopy.IsDefender());
    }

    [Fact]
    public void Line_matches_product_engine_copy_and_contains_disclaimer()
    {
        Assert.Equal(ProductEngineCopy.Line(), ProductEngineHeadlineCopy.Line());
        Assert.Contains(ProductDisclaimer.Engine, ProductEngineHeadlineCopy.Line());
        Assert.StartsWith("engine-product=", ProductEngineHeadlineCopy.Line());
    }
}
