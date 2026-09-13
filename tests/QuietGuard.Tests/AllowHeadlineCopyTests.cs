using QuietGuard;

namespace QuietGuard.Tests;

public class AllowHeadlineCopyTests
{
    [Fact]
    public void Button_is_allow_and_equals_copy()
    {
        Assert.Equal("허용", AllowHeadlineCopy.Button());
        Assert.Equal(AllowCopy.Button(), AllowHeadlineCopy.Button());
        Assert.Equal(ThreatActionLabels.Button(ThreatActionKind.Allow), AllowHeadlineCopy.Button());
    }

    [Fact]
    public void ActionId_is_six()
    {
        Assert.Equal(6, AllowHeadlineCopy.ActionId);
        Assert.Equal(AllowCopy.ActionId, AllowHeadlineCopy.ActionId);
        Assert.Equal(PreferenceActionText.AllowId, AllowHeadlineCopy.ActionId);
    }
}
