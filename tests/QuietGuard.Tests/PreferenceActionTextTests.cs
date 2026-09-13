using QuietGuard;

namespace QuietGuard.Tests;

public class PreferenceActionTextTests
{
    [Fact]
    public void Name_allow_id_is_allow_and_IsAllow_is_true()
    {
        Assert.Equal("허용", PreferenceActionText.Name(6));
        Assert.True(PreferenceActionText.IsAllow(6));
    }

    [Fact]
    public void Name_quarantine_id_is_quarantine()
    {
        Assert.Equal("격리", PreferenceActionText.Name(2));
    }

    [Fact]
    public void Name_unknown_contains_id()
    {
        Assert.Contains("99", PreferenceActionText.Name(99));
    }

    [Fact]
    public void AllowId_is_six()
    {
        Assert.Equal(6, PreferenceActionText.AllowId);
    }
}
