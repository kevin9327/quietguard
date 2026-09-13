using QuietGuard;

namespace QuietGuard.Tests;

public class AntivirusQuietCopyTests
{
    [Fact]
    public void Enabled_matches_antivirus_enabled_copy()
    {
        Assert.Equal(AntivirusEnabledCopy.IsQuiet(true), AntivirusQuietCopy.IsQuiet(true));
        Assert.Equal(AntivirusEnabledCopy.Headline(true), AntivirusQuietCopy.Headline(true));
    }

    [Fact]
    public void Disabled_matches_antivirus_enabled_copy()
    {
        Assert.Equal(AntivirusEnabledCopy.IsQuiet(false), AntivirusQuietCopy.IsQuiet(false));
        Assert.Equal(AntivirusEnabledCopy.Headline(false), AntivirusQuietCopy.Headline(false));
    }

    [Fact]
    public void Status_overload_matches_enabled_copy()
    {
        var status = new DefenderStatus(
            false, true, true, true, true, true, false,
            DateTime.Now, DateTime.Now, DateTime.Now, "1", "1", "0");
        Assert.Equal(AntivirusEnabledCopy.IsQuiet(status), AntivirusQuietCopy.IsQuiet(status));
    }
}
