using QuietGuard;

namespace QuietGuard.Tests;

public class ProductConstCopyTests
{
    [Fact]
    public void Engine_equals_microsoft_defender_and_product_disclaimer()
    {
        Assert.Equal("Microsoft Defender", ProductConstCopy.Engine);
        Assert.Equal(ProductDisclaimer.Engine, ProductConstCopy.Engine);
    }

    [Fact]
    public void NotAhnLab_equals_product_disclaimer_and_contains_ahnlab_v3()
    {
        Assert.Equal(ProductDisclaimer.NotAhnLab, ProductConstCopy.NotAhnLab);
        Assert.Contains("AhnLab V3", ProductConstCopy.NotAhnLab);
    }

    [Fact]
    public void Footer_contains_engine_and_not_ahnlab()
    {
        var footer = ProductDisclaimer.Footer();

        Assert.Contains(ProductConstCopy.Engine, footer);
        Assert.Contains(ProductConstCopy.NotAhnLab, footer);
    }
}
