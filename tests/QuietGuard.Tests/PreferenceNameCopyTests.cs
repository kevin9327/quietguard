using QuietGuard;

namespace QuietGuard.Tests;

public class PreferenceNameCopyTests
{
    [Fact]
    public void Name_one_is_clean_and_equals_PreferenceActionText()
    {
        Assert.Equal("정리", PreferenceNameCopy.Name(1));
        Assert.Equal(PreferenceActionText.Name(1), PreferenceNameCopy.Name(1));
    }

    [Fact]
    public void Name_two_is_quarantine_and_equals_PreferenceActionText()
    {
        Assert.Equal("격리", PreferenceNameCopy.Name(2));
        Assert.Equal(PreferenceActionText.Name(2), PreferenceNameCopy.Name(2));
    }

    [Fact]
    public void Name_three_is_remove_and_equals_PreferenceActionText()
    {
        Assert.Equal("제거", PreferenceNameCopy.Name(3));
        Assert.Equal(PreferenceActionText.Name(3), PreferenceNameCopy.Name(3));
    }

    [Fact]
    public void Name_eight_is_custom_and_equals_PreferenceActionText()
    {
        Assert.Equal("사용자 지정", PreferenceNameCopy.Name(8));
        Assert.Equal(PreferenceActionText.Name(8), PreferenceNameCopy.Name(8));
    }

    [Fact]
    public void Name_nine_is_block_and_equals_PreferenceActionText()
    {
        Assert.Equal("차단", PreferenceNameCopy.Name(9));
        Assert.Equal(PreferenceActionText.Name(9), PreferenceNameCopy.Name(9));
    }

    [Fact]
    public void Name_ten_is_none_and_equals_PreferenceActionText()
    {
        Assert.Equal("없음", PreferenceNameCopy.Name(10));
        Assert.Equal(PreferenceActionText.Name(10), PreferenceNameCopy.Name(10));
    }

    [Fact]
    public void Name_unknown_is_action_id_and_equals_PreferenceActionText()
    {
        Assert.Equal("동작 99", PreferenceNameCopy.Name(99));
        Assert.Equal(PreferenceActionText.Name(99), PreferenceNameCopy.Name(99));
    }
}
