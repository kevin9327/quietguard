using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatCanActCopyTests
{
    [Fact]
    public void Path_bearing_threat_can_restore_and_equals_actions()
    {
        var threat = Sample(@"C:\Users\a\Downloads\payload.exe");
        Assert.True(ThreatCanActCopy.CanRestore(threat));
        Assert.True(ThreatCanActCopy.CanAct(ThreatActionKind.Restore, threat));
        Assert.Equal(
            ThreatActions.CanAct(ThreatActionKind.Restore, threat),
            ThreatCanActCopy.CanAct(ThreatActionKind.Restore, threat));
        Assert.Equal(
            ThreatActions.CanAct(ThreatActionKind.Remediate, threat),
            ThreatCanActCopy.CanAct(ThreatActionKind.Remediate, threat));
    }

    [Fact]
    public void Empty_path_cannot_restore()
    {
        var threat = Sample("");
        Assert.False(ThreatCanActCopy.CanRestore(threat));
        Assert.False(ThreatCanActCopy.CanAct(ThreatActionKind.Restore, threat));
        Assert.Equal(
            ThreatActions.CanAct(ThreatActionKind.Restore, threat),
            ThreatCanActCopy.CanAct(ThreatActionKind.Restore, threat));
    }

    [Fact]
    public void Named_threat_can_allow_without_path()
    {
        var threat = Sample("") with { Name = "Trojan:Win32/Test" };
        Assert.True(ThreatCanActCopy.CanAct(ThreatActionKind.Allow, threat));
        Assert.Equal(
            ThreatActions.CanAct(ThreatActionKind.Allow, threat),
            ThreatCanActCopy.CanAct(ThreatActionKind.Allow, threat));
    }

    private static ThreatInfo Sample(string path) => new(
        Name: "Trojan:Win32/Test",
        Path: path,
        State: "Quarantined",
        DetectedAt: DateTime.Now);
}
