using QuietGuard;

namespace QuietGuard.Tests;

public class HashFormatHeadlineCopyTests
{
    private const string Sha = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef";

    [Fact]
    public void Valid_sha256_formats_lower_and_equals_hash_format_copy_and_hash_text()
    {
        Assert.Equal(Sha, HashFormatHeadlineCopy.Format(Sha.ToUpperInvariant()));
        Assert.Equal(HashFormatCopy.Format(Sha.ToUpperInvariant()), HashFormatHeadlineCopy.Format(Sha.ToUpperInvariant()));
        Assert.Equal(HashText.FormatSha256(Sha.ToUpperInvariant()), HashFormatHeadlineCopy.Format(Sha.ToUpperInvariant()));
        Assert.True(HashFormatHeadlineCopy.LooksValid(Sha));
        Assert.Equal(HashFormatCopy.LooksValid(Sha), HashFormatHeadlineCopy.LooksValid(Sha));
        Assert.Equal(HashText.LooksLikeSha256(Sha), HashFormatHeadlineCopy.LooksValid(Sha));
    }

    [Fact]
    public void Empty_and_short_are_hash_none()
    {
        Assert.Equal("해시 없음", HashFormatHeadlineCopy.Format(null));
        Assert.Equal(HashFormatCopy.Format(null), HashFormatHeadlineCopy.Format(null));
        Assert.Equal(HashText.FormatSha256(null), HashFormatHeadlineCopy.Format(null));
        Assert.Equal("해시 없음", HashFormatHeadlineCopy.Format("abc"));
        Assert.False(HashFormatHeadlineCopy.LooksValid("abc"));
        Assert.Equal(HashFormatCopy.LooksValid("abc"), HashFormatHeadlineCopy.LooksValid("abc"));
        Assert.Equal(HashText.LooksLikeSha256("abc"), HashFormatHeadlineCopy.LooksValid("abc"));
    }
}
