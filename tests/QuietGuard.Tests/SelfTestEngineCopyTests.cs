using QuietGuard;

namespace QuietGuard.Tests;

public class SelfTestEngineCopyTests
{
    [Fact]
    public void EngineLine_equals_banner_and_starts_with_engine_product()
    {
        Assert.Equal(SelfTestBanner.EngineLine(), SelfTestEngineCopy.EngineLine());
        Assert.StartsWith("engine-product=", SelfTestEngineCopy.EngineLine());
    }

    [Fact]
    public void EngineLine_contains_product_disclaimer_engine_and_microsoft_defender()
    {
        Assert.Contains(ProductDisclaimer.Engine, SelfTestEngineCopy.EngineLine());
        Assert.Contains("Microsoft Defender", SelfTestEngineCopy.EngineLine());
    }

    [Fact]
    public void Engine_equals_product_disclaimer_and_product_const()
    {
        Assert.Equal(ProductDisclaimer.Engine, SelfTestEngineCopy.Engine());
        Assert.Equal(ProductConstCopy.Engine, SelfTestEngineCopy.Engine());
    }
}
