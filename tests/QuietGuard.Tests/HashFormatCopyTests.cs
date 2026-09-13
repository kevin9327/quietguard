using QuietGuard;

namespace QuietGuard.Tests;

public class HashFormatCopyTests
{
    private const string Sha = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef";

    [Fact]
    public void Valid_sha256_formats_lower_and_equals_hash_text()
    {
        Assert.Equal(Sha, HashFormatCopy.Format(Sha.ToUpperInvariant()));
        Assert.Equal(HashText.FormatSha256(Sha.ToUpperInvariant()), HashFormatCopy.Format(Sha.ToUpperInvariant()));
        Assert.True(HashFormatCopy.LooksValid(Sha));
        Assert.Equal(HashText.LooksLikeSha256(Sha), HashFormatCopy.LooksValid(Sha));
    }

    [Fact]
    public void Empty_and_short_are_hash_none()
    {
        Assert.Equal("해시 없음", HashFormatCopy.Format(null));
        Assert.Equal(HashText.FormatSha256(null), HashFormatCopy.Format(null));
        Assert.Equal("해시 없음", HashFormatCopy.Format("abc"));
        Assert.False(HashFormatCopy.LooksValid("abc"));
        Assert.Equal(HashText.LooksLikeSha256("abc"), HashFormatCopy.LooksValid("abc"));
    }
}
