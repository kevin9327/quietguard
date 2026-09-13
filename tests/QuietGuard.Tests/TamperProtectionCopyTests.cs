using QuietGuard;

namespace QuietGuard.Tests;

public class TamperProtectionCopyTests
{
    [Fact]
    public void Enabled_is_quiet()
    {
        Assert.True(TamperProtectionCopy.IsQuiet(true));
        Assert.Equal("변조 방지 켜짐", TamperProtectionCopy.Headline(true));
    }

    [Fact]
    public void Disabled_mentions_off()
    {
        Assert.False(TamperProtectionCopy.IsQuiet(false));
        Assert.Contains("꺼져", TamperProtectionCopy.Headline(false));
    }

    [Fact]
    public void Status_overload_matches_bool()
    {
        var status = new DefenderStatus(
            true, true, true, true, true, false, false,
            DateTime.Now, DateTime.Now, DateTime.Now, "1", "1", "0");
        Assert.Equal(TamperProtectionCopy.Headline(false), TamperProtectionCopy.Headline(status));
        Assert.False(TamperProtectionCopy.IsQuiet(status));
    }
}
