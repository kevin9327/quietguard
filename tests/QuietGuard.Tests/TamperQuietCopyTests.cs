using QuietGuard;

namespace QuietGuard.Tests;

public class TamperQuietCopyTests
{
    [Fact]
    public void Enabled_matches_tamper_protection_copy()
    {
        Assert.Equal(TamperProtectionCopy.IsQuiet(true), TamperQuietCopy.IsQuiet(true));
        Assert.True(TamperQuietCopy.IsQuiet(true));
        Assert.Equal(TamperProtectionCopy.Headline(true), TamperQuietCopy.Headline(true));
    }

    [Fact]
    public void Disabled_matches_tamper_protection_copy()
    {
        Assert.Equal(TamperProtectionCopy.IsQuiet(false), TamperQuietCopy.IsQuiet(false));
        Assert.False(TamperQuietCopy.IsQuiet(false));
        Assert.Equal(TamperProtectionCopy.Headline(false), TamperQuietCopy.Headline(false));
        Assert.Contains("꺼져", TamperQuietCopy.Headline(false));
    }

    [Fact]
    public void Status_overload_matches_bool()
    {
        var status = new DefenderStatus(
            true, true, true, true, true, false, false,
            DateTime.Now, DateTime.Now, DateTime.Now, "1", "1", "0");
        Assert.Equal(TamperProtectionCopy.IsQuiet(status), TamperQuietCopy.IsQuiet(status));
        Assert.False(TamperQuietCopy.IsQuiet(status));
    }
}
