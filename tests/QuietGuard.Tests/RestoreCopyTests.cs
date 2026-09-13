using QuietGuard;

namespace QuietGuard.Tests;

public class RestoreCopyTests
{
    [Fact]
    public void Button_matches_threat_action_label()
    {
        Assert.Equal(ThreatActionLabels.Button(ThreatActionKind.Restore), RestoreCopy.Button());
        Assert.Equal("복원", RestoreCopy.Button());
    }

    [Fact]
    public void FileArguments_match_RestoreAllArgs_and_ThreatActions_Plan()
    {
        var path = @"C:\Users\a\Downloads\payload.exe";
        var threat = new ThreatInfo("Trojan:Win32/Test", path, "Quarantined", DateTime.Now);
        var expected = ThreatActions.Plan(ThreatActionKind.Restore, threat).Arguments;

        Assert.Equal(RestoreAllArgs.File(path), RestoreCopy.FileArguments(path));
        Assert.Equal(expected, RestoreCopy.FileArguments(path));
    }

    [Fact]
    public void AllArguments_match_RestoreAllArgs()
    {
        Assert.Equal(RestoreAllArgs.All(), RestoreCopy.AllArguments());
    }
}
