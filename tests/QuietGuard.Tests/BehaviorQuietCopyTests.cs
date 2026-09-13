using QuietGuard;

namespace QuietGuard.Tests;

public class BehaviorQuietCopyTests
{
    [Fact]
    public void Enabled_matches_behavior_protection_copy()
    {
        Assert.Equal(BehaviorProtectionCopy.IsQuiet(true), BehaviorQuietCopy.IsQuiet(true));
        Assert.True(BehaviorQuietCopy.IsQuiet(true));
        Assert.Equal(BehaviorProtectionCopy.Headline(true), BehaviorQuietCopy.Headline(true));
    }

    [Fact]
    public void Disabled_matches_behavior_protection_copy()
    {
        Assert.Equal(BehaviorProtectionCopy.IsQuiet(false), BehaviorQuietCopy.IsQuiet(false));
        Assert.False(BehaviorQuietCopy.IsQuiet(false));
        Assert.Equal(BehaviorProtectionCopy.Headline(false), BehaviorQuietCopy.Headline(false));
    }

    [Fact]
    public void Status_overload_matches()
    {
        var status = new DefenderStatus(
            true, true, true, false, true, true, false,
            DateTime.Now, DateTime.Now, DateTime.Now, "1", "1", "0");
        Assert.Equal(BehaviorProtectionCopy.Headline(status), BehaviorQuietCopy.Headline(status));
    }
}
