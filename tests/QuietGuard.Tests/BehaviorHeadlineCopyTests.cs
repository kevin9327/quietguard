using QuietGuard;

namespace QuietGuard.Tests;

public class BehaviorHeadlineCopyTests
{
    [Fact]
    public void Enabled_is_quiet_and_equals_behavior_quiet_copy()
    {
        Assert.True(BehaviorHeadlineCopy.IsQuiet(true));
        Assert.Equal(BehaviorQuietCopy.IsQuiet(true), BehaviorHeadlineCopy.IsQuiet(true));
        Assert.Equal(BehaviorProtectionCopy.IsQuiet(true), BehaviorHeadlineCopy.IsQuiet(true));
        Assert.Equal(BehaviorQuietCopy.Headline(true), BehaviorHeadlineCopy.Headline(true));
        Assert.Equal(BehaviorProtectionCopy.Headline(true), BehaviorHeadlineCopy.Headline(true));
    }

    [Fact]
    public void Disabled_is_not_quiet()
    {
        Assert.False(BehaviorHeadlineCopy.IsQuiet(false));
        Assert.Equal(BehaviorQuietCopy.IsQuiet(false), BehaviorHeadlineCopy.IsQuiet(false));
        Assert.Equal(BehaviorQuietCopy.Headline(false), BehaviorHeadlineCopy.Headline(false));
        Assert.Equal(BehaviorProtectionCopy.Headline(false), BehaviorHeadlineCopy.Headline(false));
    }
}
