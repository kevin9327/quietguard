using QuietGuard;

namespace QuietGuard.Tests;

public class CloudQuietCopyTests
{
    [Fact]
    public void Both_true_matches_cloud_protection_copy()
    {
        Assert.Equal(CloudProtectionCopy.IsQuiet(true, true), CloudQuietCopy.IsQuiet(true, true));
        Assert.Equal(CloudProtectionCopy.Headline(true, true), CloudQuietCopy.Headline(true, true));
    }

    [Fact]
    public void Ioav_false_headline_matches_cloud_protection_copy()
    {
        Assert.Equal(CloudProtectionCopy.Headline(false, true), CloudQuietCopy.Headline(false, true));
    }

    [Fact]
    public void Status_overload_matches_headline()
    {
        var status = new DefenderStatus(
            true, true, true, false, true, true, false,
            DateTime.Now, DateTime.Now, DateTime.Now, "1", "1", "0");
        Assert.Equal(CloudProtectionCopy.Headline(status), CloudQuietCopy.Headline(status));
    }
}
