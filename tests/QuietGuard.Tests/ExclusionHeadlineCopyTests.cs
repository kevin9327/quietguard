using QuietGuard;

namespace QuietGuard.Tests;

public class ExclusionHeadlineCopyTests
{
    [Fact]
    public void Headline_zero_equals_format()
    {
        Assert.Equal(ExclusionCountText.Format(0), ExclusionHeadlineCopy.Headline(0));
    }

    [Fact]
    public void Headline_two_equals_format()
    {
        Assert.Equal(ExclusionCountText.Format(2), ExclusionHeadlineCopy.Headline(2));
    }

    [Fact]
    public void DefaultHeadline_equals_format_default_and_default_quiet_exclusions_count()
    {
        var count = PathExclusion.DefaultQuietExclusions().Count;

        Assert.Equal(ExclusionCountText.FormatDefault(), ExclusionHeadlineCopy.DefaultHeadline());
        Assert.Equal(ExclusionCountText.Format(count), ExclusionHeadlineCopy.DefaultHeadline());
    }
}
