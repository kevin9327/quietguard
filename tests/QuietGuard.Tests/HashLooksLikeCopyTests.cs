using QuietGuard;

namespace QuietGuard.Tests;

public class HashLooksLikeCopyTests
{
    private const string SixtyFourAs = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

    [Fact]
    public void LooksValid_64_as_is_true_and_equals_LooksLikeSha256()
    {
        Assert.True(HashLooksLikeCopy.LooksValid(SixtyFourAs));
        Assert.Equal(HashText.LooksLikeSha256(SixtyFourAs), HashLooksLikeCopy.LooksValid(SixtyFourAs));
    }

    [Fact]
    public void Headline_64_as_equals_FormatSha256_lowercase()
    {
        Assert.Equal(HashText.FormatSha256(SixtyFourAs), HashLooksLikeCopy.Headline(SixtyFourAs));
        Assert.Equal(SixtyFourAs, HashLooksLikeCopy.Headline(SixtyFourAs));
        Assert.Equal(SixtyFourAs, HashLooksLikeCopy.Headline(new string('A', 64)));
    }

    [Fact]
    public void LooksValid_null_is_false()
    {
        Assert.False(HashLooksLikeCopy.LooksValid(null));
        Assert.Equal(HashText.LooksLikeSha256(null), HashLooksLikeCopy.LooksValid(null));
    }

    [Fact]
    public void Headline_null_is_invalid_sha256()
    {
        Assert.Equal("유효한 SHA256 아님", HashLooksLikeCopy.Headline(null));
    }
}
