using QuietGuard;

namespace QuietGuard.Tests;

public class DefinitionFreshHeadlineCopyTests
{
    [Fact]
    public void Fresh_hour_old_is_fresh()
    {
        Assert.True(DefinitionFreshHeadlineCopy.IsFresh(false, TimeSpan.FromHours(1)));
        Assert.Equal(
            DefinitionFreshCopy.IsFresh(false, TimeSpan.FromHours(1)),
            DefinitionFreshHeadlineCopy.IsFresh(false, TimeSpan.FromHours(1)));
        Assert.Equal("정의가 최신입니다", DefinitionFreshHeadlineCopy.Headline(false, TimeSpan.FromHours(1)));
        Assert.Equal(
            DefinitionFreshCopy.Headline(false, TimeSpan.FromHours(1)),
            DefinitionFreshHeadlineCopy.Headline(false, TimeSpan.FromHours(1)));
    }

    [Fact]
    public void Out_of_date_needs_update()
    {
        Assert.False(DefinitionFreshHeadlineCopy.IsFresh(true, TimeSpan.FromDays(8)));
        Assert.Equal(
            DefinitionFreshCopy.IsFresh(true, TimeSpan.FromDays(8)),
            DefinitionFreshHeadlineCopy.IsFresh(true, TimeSpan.FromDays(8)));
        Assert.Equal("정의 갱신이 필요합니다", DefinitionFreshHeadlineCopy.Headline(true, TimeSpan.FromDays(8)));
        Assert.Equal(
            DefinitionFreshCopy.Headline(true, TimeSpan.FromDays(8)),
            DefinitionFreshHeadlineCopy.Headline(true, TimeSpan.FromDays(8)));
    }
}
