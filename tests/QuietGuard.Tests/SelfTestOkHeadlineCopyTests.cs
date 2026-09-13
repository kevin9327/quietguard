using QuietGuard;

namespace QuietGuard.Tests;

public class SelfTestOkHeadlineCopyTests
{
    [Fact]
    public void Ok_equals_copy_and_banner()
    {
        Assert.Equal("quietguard.self-test=ok", SelfTestOkHeadlineCopy.Ok());
        Assert.Equal(SelfTestOkCopy.Ok(), SelfTestOkHeadlineCopy.Ok());
        Assert.Equal(SelfTestBanner.Ok(), SelfTestOkHeadlineCopy.Ok());
    }

    [Fact]
    public void Fail_x_equals_copy_and_banner()
    {
        Assert.Equal(SelfTestOkCopy.Fail("x"), SelfTestOkHeadlineCopy.Fail("x"));
        Assert.Equal(SelfTestBanner.Fail("x"), SelfTestOkHeadlineCopy.Fail("x"));
        Assert.Contains("fail", SelfTestOkHeadlineCopy.Fail("x"));
        Assert.Contains("x", SelfTestOkHeadlineCopy.Fail("x"));
    }
}
