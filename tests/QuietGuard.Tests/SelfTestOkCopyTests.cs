using QuietGuard;

namespace QuietGuard.Tests;

public class SelfTestOkCopyTests
{
    [Fact]
    public void Ok_equals_banner_and_is_exact()
    {
        Assert.Equal(SelfTestBanner.Ok(), SelfTestOkCopy.Ok());
        Assert.Equal("quietguard.self-test=ok", SelfTestOkCopy.Ok());
    }

    [Fact]
    public void Fail_x_equals_banner()
    {
        Assert.Equal(SelfTestBanner.Fail("x"), SelfTestOkCopy.Fail("x"));
    }

    [Fact]
    public void MpCmdName_equals_WinDefend_and_banner()
    {
        Assert.Equal(WinDefendNames.CommandLine, SelfTestOkCopy.MpCmdName());
        Assert.Equal(SelfTestBanner.CommandLineName(), SelfTestOkCopy.MpCmdName());
    }
}
