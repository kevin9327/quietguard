using QuietGuard;

namespace QuietGuard.Tests;

public class DefinitionFreshCopyTests
{
    [Fact]
    public void Fresh_age_without_flag_is_current()
    {
        var age = TimeSpan.FromHours(2);

        Assert.True(DefinitionFreshCopy.IsFresh(false, age));
        Assert.Equal(!DefinitionUpdateAdvisor.ShouldUpdate(false, age), DefinitionFreshCopy.IsFresh(false, age));
        Assert.Equal("정의가 최신입니다", DefinitionFreshCopy.Headline(false, age));
    }

    [Fact]
    public void Stale_age_without_flag_needs_update()
    {
        var age = TimeSpan.FromDays(8);

        Assert.False(DefinitionFreshCopy.IsFresh(false, age));
        Assert.True(DefinitionUpdateAdvisor.ShouldUpdate(false, age));
        Assert.Equal("정의 갱신이 필요합니다", DefinitionFreshCopy.Headline(false, age));
    }

    [Fact]
    public void Out_of_date_flag_is_not_fresh_even_when_age_is_fresh()
    {
        var age = TimeSpan.FromHours(2);

        Assert.False(DefinitionFreshCopy.IsFresh(true, age));
    }
}
