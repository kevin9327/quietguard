using QuietGuard;

namespace QuietGuard.Tests;

public class NisQuietCopyTests
{
    [Fact]
    public void Enabled_matches_nis_protection_copy()
    {
        Assert.Equal(NisProtectionCopy.IsQuiet(true), NisQuietCopy.IsQuiet(true));
        Assert.Equal(NisProtectionCopy.Headline(true), NisQuietCopy.Headline(true));
    }

    [Fact]
    public void Disabled_matches_nis_protection_copy()
    {
        Assert.Equal(NisProtectionCopy.IsQuiet(false), NisQuietCopy.IsQuiet(false));
        Assert.Equal(NisProtectionCopy.Headline(false), NisQuietCopy.Headline(false));
    }

    [Fact]
    public void Status_overload_matches_protection_copy()
    {
        var status = new DefenderStatus(
            true, true, true, true, false, true, false,
            DateTime.Now, DateTime.Now, DateTime.Now, "1", "1", "0");
        Assert.Equal(NisProtectionCopy.IsQuiet(status), NisQuietCopy.IsQuiet(status));
    }
}
