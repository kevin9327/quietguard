using QuietGuard;

namespace QuietGuard.Tests;

public class PreferenceAllowCopyTests
{
    [Fact]
    public void AllowId_equals_PreferenceActionText_AllowId_and_six()
    {
        Assert.Equal(PreferenceActionText.AllowId, PreferenceAllowCopy.AllowId);
        Assert.Equal(6, PreferenceAllowCopy.AllowId);
    }

    [Fact]
    public void IsAllow_six_is_true_and_equals_PreferenceActionText()
    {
        Assert.True(PreferenceAllowCopy.IsAllow(6));
        Assert.Equal(PreferenceActionText.IsAllow(6), PreferenceAllowCopy.IsAllow(6));
    }

    [Fact]
    public void Name_six_is_allow_and_equals_PreferenceActionText()
    {
        Assert.Equal("허용", PreferenceAllowCopy.Name(6));
        Assert.Equal(PreferenceActionText.Name(6), PreferenceAllowCopy.Name(6));
    }

    [Fact]
    public void Name_two_is_quarantine()
    {
        Assert.Equal("격리", PreferenceAllowCopy.Name(2));
    }
}
