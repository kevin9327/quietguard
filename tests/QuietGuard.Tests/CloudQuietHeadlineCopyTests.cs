using QuietGuard;

namespace QuietGuard.Tests;

public class CloudQuietHeadlineCopyTests
{
    [Fact]
    public void Both_on_is_quiet_and_equals_cloud_quiet_copy()
    {
        Assert.True(CloudQuietHeadlineCopy.IsQuiet(true, true));
        Assert.Equal(CloudQuietCopy.IsQuiet(true, true), CloudQuietHeadlineCopy.IsQuiet(true, true));
        Assert.Equal(CloudProtectionCopy.IsQuiet(true, true), CloudQuietHeadlineCopy.IsQuiet(true, true));
        Assert.Equal(CloudQuietCopy.Headline(true, true), CloudQuietHeadlineCopy.Headline(true, true));
        Assert.Equal(CloudProtectionCopy.Headline(true, true), CloudQuietHeadlineCopy.Headline(true, true));
    }

    [Fact]
    public void Ioav_off_is_not_quiet()
    {
        Assert.False(CloudQuietHeadlineCopy.IsQuiet(false, true));
        Assert.Equal(CloudQuietCopy.IsQuiet(false, true), CloudQuietHeadlineCopy.IsQuiet(false, true));
        Assert.Equal(CloudQuietCopy.Headline(false, true), CloudQuietHeadlineCopy.Headline(false, true));
        Assert.Equal(CloudProtectionCopy.Headline(false, true), CloudQuietHeadlineCopy.Headline(false, true));
    }
}
