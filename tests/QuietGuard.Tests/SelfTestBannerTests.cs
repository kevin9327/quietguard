using QuietGuard;

namespace QuietGuard.Tests;

public class SelfTestBannerTests
{
    [Fact]
    public void Ok_is_exact()
    {
        Assert.Equal("quietguard.self-test=ok", SelfTestBanner.Ok());
    }

    [Fact]
    public void Fail_contains_fail_and_the_message()
    {
        const string message = "timeout";
        var line = SelfTestBanner.Fail(message);
        Assert.Contains("fail", line);
        Assert.Contains(message, line);
    }

    [Fact]
    public void EngineLine_contains_engine_product()
    {
        Assert.Contains(ProductDisclaimer.Engine, SelfTestBanner.EngineLine());
    }

    [Fact]
    public void CommandLineName_equals_MpCmdRun_via_WinDefendNames()
    {
        Assert.Equal("MpCmdRun.exe", SelfTestBanner.CommandLineName());
        Assert.Equal(WinDefendNames.CommandLine, SelfTestBanner.CommandLineName());
    }
}
