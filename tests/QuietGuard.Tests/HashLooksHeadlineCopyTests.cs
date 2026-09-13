using QuietGuard;

namespace QuietGuard.Tests;

public class HashLooksHeadlineCopyTests
{
    private const string SixtyFourAs = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

    [Fact]
    public void LooksValid_64_hex_equals_hash_looks_like_copy_and_format_sha256()
    {
        Assert.True(HashLooksHeadlineCopy.LooksValid(SixtyFourAs));
        Assert.Equal(HashLooksLikeCopy.LooksValid(SixtyFourAs), HashLooksHeadlineCopy.LooksValid(SixtyFourAs));
        Assert.Equal(HashText.FormatSha256(SixtyFourAs), HashLooksHeadlineCopy.Headline(SixtyFourAs));
        Assert.Equal(HashLooksLikeCopy.Headline(SixtyFourAs), HashLooksHeadlineCopy.Headline(SixtyFourAs));
    }

    [Fact]
    public void Headline_abc_is_invalid_sha256_and_equals_hash_looks_like_copy()
    {
        Assert.Equal("유효한 SHA256 아님", HashLooksHeadlineCopy.Headline("abc"));
        Assert.Equal(HashLooksLikeCopy.Headline("abc"), HashLooksHeadlineCopy.Headline("abc"));
        Assert.Equal(HashLooksLikeCopy.LooksValid("abc"), HashLooksHeadlineCopy.LooksValid("abc"));
        Assert.False(HashLooksHeadlineCopy.LooksValid("abc"));
    }
}
