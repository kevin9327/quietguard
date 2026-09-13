using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatActionTests
{
    [Fact]
    public void Restore_plans_elevated_MpCmdRun_with_quoted_path()
    {
        var threat = SampleThreat();
        Assert.True(ThreatActions.CanAct(ThreatActionKind.Restore, threat));

        var plan = ThreatActions.Plan(ThreatActionKind.Restore, threat);

        Assert.Equal(ThreatActionKind.Restore, plan.Kind);
        Assert.Equal("MpCmdRun.exe", plan.FileName);
        Assert.Contains("-Restore", plan.Arguments);
        Assert.Contains("\"" + threat.Path + "\"", plan.Arguments);
        Assert.True(plan.RequiresElevation);
        Assert.True(plan.NotifyUser);
        Assert.False(string.IsNullOrWhiteSpace(plan.Summary));
    }

    [Fact]
    public void Allow_plans_elevated_powershell_with_threat_id()
    {
        var threat = SampleThreat() with { Name = "2147598187" };
        Assert.True(ThreatActions.CanAct(ThreatActionKind.Allow, threat));

        var plan = ThreatActions.Plan(ThreatActionKind.Allow, threat);

        Assert.Equal(ThreatActionKind.Allow, plan.Kind);
        Assert.Equal("powershell.exe", plan.FileName);
        Assert.Contains("Add-MpPreference", plan.Arguments);
        Assert.Contains("ThreatIDDefaultAction", plan.Arguments);
        Assert.Contains("2147598187", plan.Arguments);
        Assert.True(plan.RequiresElevation);
        Assert.True(plan.NotifyUser);
        Assert.False(string.IsNullOrWhiteSpace(plan.Summary));
    }

    [Fact]
    public void Allow_uses_path_when_name_is_not_an_id()
    {
        var threat = SampleThreat();
        Assert.True(ThreatActions.CanAct(ThreatActionKind.Allow, threat));

        var plan = ThreatActions.Plan(ThreatActionKind.Allow, threat);

        Assert.Equal("powershell.exe", plan.FileName);
        Assert.Contains("Add-MpPreference", plan.Arguments);
        Assert.Contains("ThreatIDDefaultAction", plan.Arguments);
        Assert.Contains(threat.Path, plan.Arguments);
        Assert.True(plan.RequiresElevation);
        Assert.True(plan.NotifyUser);
    }

    [Fact]
    public void Remediate_plans_custom_file_scan_without_elevation()
    {
        var threat = SampleThreat();
        Assert.True(ThreatActions.CanAct(ThreatActionKind.Remediate, threat));

        var plan = ThreatActions.Plan(ThreatActionKind.Remediate, threat);

        Assert.Equal(ThreatActionKind.Remediate, plan.Kind);
        Assert.Equal("MpCmdRun.exe", plan.FileName);
        Assert.Contains("-Scan", plan.Arguments);
        Assert.Contains("-ScanType 3", plan.Arguments);
        Assert.Contains("-File", plan.Arguments);
        Assert.Contains("\"" + threat.Path + "\"", plan.Arguments);
        Assert.False(plan.RequiresElevation);
        Assert.True(plan.NotifyUser);
        Assert.False(string.IsNullOrWhiteSpace(plan.Summary));
    }

    [Fact]
    public void CanAct_is_false_when_path_is_empty()
    {
        var emptyPath = SampleThreat() with { Path = "" };
        var whitespacePath = SampleThreat() with { Path = "   " };

        Assert.False(ThreatActions.CanAct(ThreatActionKind.Restore, emptyPath));
        Assert.False(ThreatActions.CanAct(ThreatActionKind.Restore, whitespacePath));
        Assert.False(ThreatActions.CanAct(ThreatActionKind.Remediate, emptyPath));
        Assert.False(ThreatActions.CanAct(ThreatActionKind.Remediate, whitespacePath));
    }

    [Fact]
    public void Allow_cannot_act_when_name_and_path_are_empty()
    {
        var empty = new ThreatInfo("", "", "0", null);
        Assert.False(ThreatActions.CanAct(ThreatActionKind.Allow, empty));
    }

    [Fact]
    public void Plan_throws_for_empty_threat_or_undefined_kind()
    {
        var empty = new ThreatInfo("", "", "", null);

        Assert.Throws<ArgumentException>(() => ThreatActions.Plan(ThreatActionKind.Restore, empty));
        Assert.Throws<ArgumentException>(() => ThreatActions.Plan((ThreatActionKind)999, SampleThreat()));
    }

    private static ThreatInfo SampleThreat() => new(
        Name: "Trojan:Win32/Test",
        Path: @"C:\Users\a\Downloads\payload.exe",
        State: "Quarantined",
        DetectedAt: DateTime.Now);
}
