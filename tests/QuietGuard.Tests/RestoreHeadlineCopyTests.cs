using QuietGuard;

namespace QuietGuard.Tests;

public class RestoreHeadlineCopyTests
{
    [Fact]
    public void Button_is_restore_and_equals_copy()
    {
        Assert.Equal("복원", RestoreHeadlineCopy.Button());
        Assert.Equal(RestoreCopy.Button(), RestoreHeadlineCopy.Button());
        Assert.Equal(ThreatActionLabels.Button(ThreatActionKind.Restore), RestoreHeadlineCopy.Button());
    }

    [Fact]
    public void AllArguments_match_restore_copy()
    {
        Assert.Equal("-Restore -All", RestoreHeadlineCopy.AllArguments());
        Assert.Equal(RestoreCopy.AllArguments(), RestoreHeadlineCopy.AllArguments());
        Assert.Equal(RestoreAllArgs.All(), RestoreHeadlineCopy.AllArguments());
    }
}
