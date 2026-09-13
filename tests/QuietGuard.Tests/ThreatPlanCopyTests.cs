using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatPlanCopyTests
{
    [Fact]
    public void Restore_arguments_contain_restore_and_quoted_path()
    {
        var threat = Sample();
        var expected = ThreatActions.Plan(ThreatActionKind.Restore, threat);
        var plan = ThreatPlanCopy.Plan(ThreatActionKind.Restore, threat);
        Assert.Equal(expected.Kind, plan.Kind);
        Assert.Equal(expected.FileName, plan.FileName);
        Assert.Equal(expected.Arguments, plan.Arguments);
        Assert.Equal(expected.RequiresElevation, plan.RequiresElevation);
        Assert.Equal("MpCmdRun.exe", plan.FileName);
        Assert.Contains("-Restore", ThreatPlanCopy.RestoreArguments(threat));
        Assert.Contains("\"" + threat.Path + "\"", ThreatPlanCopy.RestoreArguments(threat));
        Assert.Equal(expected.Arguments, ThreatPlanCopy.RestoreArguments(threat));
    }

    [Fact]
    public void Allow_id_uses_powershell_and_matches_plan()
    {
        var threat = Sample() with { Name = "2147598187" };
        var expected = ThreatActions.Plan(ThreatActionKind.Allow, threat);
        var plan = ThreatPlanCopy.Plan(ThreatActionKind.Allow, threat);
        Assert.Equal(expected.FileName, plan.FileName);
        Assert.Equal(expected.Arguments, plan.Arguments);
        Assert.Equal("powershell.exe", plan.FileName);
        Assert.Contains("Add-MpPreference", plan.Arguments);
        Assert.Contains("2147598187", plan.Arguments);
    }

    private static ThreatInfo Sample() => new(
        Name: "Trojan:Win32/Test",
        Path: @"C:\Users\a\Downloads\payload.exe",
        State: "Quarantined",
        DetectedAt: DateTime.Now);
}
