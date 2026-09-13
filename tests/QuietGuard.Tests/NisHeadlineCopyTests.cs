using QuietGuard;

namespace QuietGuard.Tests;

public class NisHeadlineCopyTests
{
    [Fact]
    public void Enabled_is_quiet_and_equals_nis_quiet_copy()
    {
        Assert.True(NisHeadlineCopy.IsQuiet(true));
        Assert.Equal(NisQuietCopy.IsQuiet(true), NisHeadlineCopy.IsQuiet(true));
        Assert.Equal(NisProtectionCopy.IsQuiet(true), NisHeadlineCopy.IsQuiet(true));
        Assert.Equal(NisQuietCopy.Headline(true), NisHeadlineCopy.Headline(true));
        Assert.Equal(NisProtectionCopy.Headline(true), NisHeadlineCopy.Headline(true));
    }

    [Fact]
    public void Disabled_is_not_quiet()
    {
        Assert.False(NisHeadlineCopy.IsQuiet(false));
        Assert.Equal(NisQuietCopy.IsQuiet(false), NisHeadlineCopy.IsQuiet(false));
        Assert.Equal(NisQuietCopy.Headline(false), NisHeadlineCopy.Headline(false));
        Assert.Equal(NisProtectionCopy.Headline(false), NisHeadlineCopy.Headline(false));
    }

    [Fact]
    public void Status_overload_matches_nis_quiet_copy()
    {
        var status = new DefenderStatus(
            true, true, true, true, false, true, false,
            DateTime.Now, DateTime.Now, DateTime.Now, "1", "1", "0");
        Assert.Equal(NisQuietCopy.IsQuiet(status), NisHeadlineCopy.IsQuiet(status));
        Assert.Equal(NisProtectionCopy.IsQuiet(status), NisHeadlineCopy.IsQuiet(status));
    }
}
