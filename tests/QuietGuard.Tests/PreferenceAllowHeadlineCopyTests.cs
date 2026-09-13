using QuietGuard;

namespace QuietGuard.Tests;

public class PreferenceAllowHeadlineCopyTests
{
    [Fact]
    public void AllowId_equals_copy_and_text_and_is_six()
    {
        Assert.Equal(6, PreferenceAllowHeadlineCopy.AllowId);
        Assert.Equal(PreferenceAllowCopy.AllowId, PreferenceAllowHeadlineCopy.AllowId);
        Assert.Equal(PreferenceActionText.AllowId, PreferenceAllowHeadlineCopy.AllowId);
    }

    [Fact]
    public void IsAllow_six_is_true_and_equals_copy_and_text()
    {
        Assert.True(PreferenceAllowHeadlineCopy.IsAllow(6));
        Assert.Equal(PreferenceAllowCopy.IsAllow(6), PreferenceAllowHeadlineCopy.IsAllow(6));
        Assert.Equal(PreferenceActionText.IsAllow(6), PreferenceAllowHeadlineCopy.IsAllow(6));
    }

    [Fact]
    public void Name_six_is_allow_and_equals_copy_and_text()
    {
        Assert.Equal("허용", PreferenceAllowHeadlineCopy.Name(6));
        Assert.Equal(PreferenceAllowCopy.Name(6), PreferenceAllowHeadlineCopy.Name(6));
        Assert.Equal(PreferenceActionText.Name(6), PreferenceAllowHeadlineCopy.Name(6));
    }

    [Fact]
    public void Name_two_is_quarantine_and_equals_copy_and_text()
    {
        Assert.Equal("격리", PreferenceAllowHeadlineCopy.Name(2));
        Assert.Equal(PreferenceAllowCopy.Name(2), PreferenceAllowHeadlineCopy.Name(2));
        Assert.Equal(PreferenceActionText.Name(2), PreferenceAllowHeadlineCopy.Name(2));
    }
}
