using QuietGuard;

namespace QuietGuard.Tests;

public class EngineProcessCopyTests
{
    [Fact]
    public void Running_headline_contains_engine_process_and_running()
    {
        var headline = EngineProcessCopy.Headline(true);
        Assert.Contains(WinDefendNames.EngineProcess, headline);
        Assert.Contains("실행 중", headline);
    }

    [Fact]
    public void Missing_headline_contains_absent()
    {
        var headline = EngineProcessCopy.Headline(false);
        Assert.Contains("없습니다", headline);
    }

    [Fact]
    public void Matches_delegates_to_IsEngineProcess()
    {
        Assert.True(EngineProcessCopy.Matches("MsMpEng"));
        Assert.True(WinDefendNames.IsEngineProcess("MsMpEng"));
        Assert.False(EngineProcessCopy.Matches("QuietGuard"));
        Assert.False(WinDefendNames.IsEngineProcess("QuietGuard"));
    }
}
