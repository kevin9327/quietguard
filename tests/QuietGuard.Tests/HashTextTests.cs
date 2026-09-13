using QuietGuard;

namespace QuietGuard.Tests;

public class HashTextTests
{
    private const string SixtyFourAs = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

    [Fact]
    public void FormatSha256_null_is_none()
    {
        Assert.Equal("해시 없음", HashText.FormatSha256(null));
    }

    [Fact]
    public void FormatSha256_short_is_none()
    {
        Assert.Equal("해시 없음", HashText.FormatSha256(""));
        Assert.Equal("해시 없음", HashText.FormatSha256("aaa"));
        Assert.Equal("해시 없음", HashText.FormatSha256(new string('a', 32)));
        Assert.Equal("해시 없음", HashText.FormatSha256(new string('a', 63)));
    }

    [Fact]
    public void FormatSha256_odd_length_is_none()
    {
        Assert.Equal("해시 없음", HashText.FormatSha256(new string('a', 1)));
        Assert.Equal("해시 없음", HashText.FormatSha256(new string('a', 63)));
        Assert.Equal("해시 없음", HashText.FormatSha256(new string('a', 65)));
    }

    [Fact]
    public void FormatSha256_64_hex_chars_are_lowercased()
    {
        Assert.Equal(SixtyFourAs, HashText.FormatSha256(SixtyFourAs));
        Assert.Equal(SixtyFourAs, HashText.FormatSha256(new string('A', 64)));
    }

    [Fact]
    public void LooksLikeSha256_true_only_for_valid_64_hex()
    {
        Assert.True(HashText.LooksLikeSha256(SixtyFourAs));
        Assert.True(HashText.LooksLikeSha256(new string('A', 64)));

        Assert.False(HashText.LooksLikeSha256(null));
        Assert.False(HashText.LooksLikeSha256(""));
        Assert.False(HashText.LooksLikeSha256("aaa"));
        Assert.False(HashText.LooksLikeSha256(new string('a', 63)));
        Assert.False(HashText.LooksLikeSha256(new string('a', 65)));
    }
}
