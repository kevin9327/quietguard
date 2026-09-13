using QuietGuard;

namespace QuietGuard.Tests;

public class ExclusionCountTextTests
{
    [Fact]
    public void Format_zero_is_none()
    {
        Assert.Equal("제외 경로 없음", ExclusionCountText.Format(0));
    }

    [Fact]
    public void Format_two_contains_count()
    {
        Assert.Contains("2", ExclusionCountText.Format(2));
    }

    [Fact]
    public void FormatDefault_count_equals_default_quiet_exclusions_count()
    {
        var count = PathExclusion.DefaultQuietExclusions().Count;

        Assert.Equal(ExclusionCountText.Format(count), ExclusionCountText.FormatDefault());
    }
}
