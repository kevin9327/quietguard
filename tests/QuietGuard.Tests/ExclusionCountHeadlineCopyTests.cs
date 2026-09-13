using QuietGuard;

namespace QuietGuard.Tests;

public class ExclusionCountHeadlineCopyTests
{
    [Fact]
    public void Headline_zero_is_none()
    {
        Assert.Equal("제외 경로 없음", ExclusionCountHeadlineCopy.Headline(0));
        Assert.Equal(ExclusionHeadlineCopy.Headline(0), ExclusionCountHeadlineCopy.Headline(0));
        Assert.Equal(ExclusionCountText.Format(0), ExclusionCountHeadlineCopy.Headline(0));
    }

    [Fact]
    public void Headline_two_contains_count()
    {
        Assert.Contains("2", ExclusionCountHeadlineCopy.Headline(2));
        Assert.Equal(ExclusionHeadlineCopy.Headline(2), ExclusionCountHeadlineCopy.Headline(2));
        Assert.Equal(ExclusionCountText.Format(2), ExclusionCountHeadlineCopy.Headline(2));
    }

    [Fact]
    public void DefaultHeadline_equals_headline_copy_and_format_default()
    {
        var count = PathExclusion.DefaultQuietExclusions().Count;

        Assert.Equal(ExclusionHeadlineCopy.DefaultHeadline(), ExclusionCountHeadlineCopy.DefaultHeadline());
        Assert.Equal(ExclusionCountText.FormatDefault(), ExclusionCountHeadlineCopy.DefaultHeadline());
        Assert.Equal(ExclusionCountText.Format(count), ExclusionCountHeadlineCopy.DefaultHeadline());
    }
}
