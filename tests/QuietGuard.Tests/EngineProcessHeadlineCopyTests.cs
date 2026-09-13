using QuietGuard;

namespace QuietGuard.Tests;

public class EngineProcessHeadlineCopyTests
{
    [Fact]
    public void Running_headline_contains_msmpeng()
    {
        Assert.Equal(EngineProcessCopy.Headline(true), EngineProcessHeadlineCopy.Headline(true));
        Assert.Contains("MsMpEng", EngineProcessHeadlineCopy.Headline(true));
        Assert.Contains("실행 중", EngineProcessHeadlineCopy.Headline(true));
        Assert.True(EngineProcessHeadlineCopy.Matches("MsMpEng"));
        Assert.Equal(EngineProcessCopy.Matches("MsMpEng"), EngineProcessHeadlineCopy.Matches("MsMpEng"));
        Assert.Equal(WinDefendNames.IsEngineProcess("MsMpEng"), EngineProcessHeadlineCopy.Matches("MsMpEng"));
    }

    [Fact]
    public void Missing_headline_says_absent()
    {
        Assert.Equal(EngineProcessCopy.Headline(false), EngineProcessHeadlineCopy.Headline(false));
        Assert.Contains("없습니다", EngineProcessHeadlineCopy.Headline(false));
        Assert.False(EngineProcessHeadlineCopy.Matches("QuietGuard"));
        Assert.Equal(WinDefendNames.IsEngineProcess("QuietGuard"), EngineProcessHeadlineCopy.Matches("QuietGuard"));
    }
}
