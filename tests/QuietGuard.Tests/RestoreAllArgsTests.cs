using QuietGuard;

namespace QuietGuard.Tests;

public class RestoreAllArgsTests
{
    [Fact]
    public void All_contains_restore_and_all()
    {
        var args = RestoreAllArgs.All();
        Assert.Contains("-Restore", args);
        Assert.Contains("-All", args);
    }

    [Fact]
    public void File_equals_ThreatActions_Plan_Restore_arguments()
    {
        var path = @"C:\Users\a\Downloads\payload.exe";
        var threat = new ThreatInfo(
            Name: "Trojan:Win32/Test",
            Path: path,
            State: "Quarantined",
            DetectedAt: DateTime.Now);

        var plan = ThreatActions.Plan(ThreatActionKind.Restore, threat);

        Assert.Equal(plan.Arguments, RestoreAllArgs.File(path));
    }

    [Fact]
    public void File_empty_throws()
    {
        Assert.Throws<ArgumentException>(() => RestoreAllArgs.File(""));
        Assert.Throws<ArgumentException>(() => RestoreAllArgs.File("   "));
    }
}
