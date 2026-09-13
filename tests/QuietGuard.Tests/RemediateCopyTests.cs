using QuietGuard;

namespace QuietGuard.Tests;

public class RemediateCopyTests
{
    [Fact]
    public void Button_matches_threat_action_label()
    {
        Assert.Equal(ThreatActionLabels.Button(ThreatActionKind.Remediate), RemediateCopy.Button());
        Assert.Equal("치료 검사", RemediateCopy.Button());
    }

    [Fact]
    public void Arguments_match_ThreatActions_Plan()
    {
        var threat = new ThreatInfo("Trojan:Win32/Test", @"C:\Users\a\Downloads\payload.exe", "6", DateTime.Now);
        var expected = ThreatActions.Plan(ThreatActionKind.Remediate, threat).Arguments;
        Assert.Equal(expected, RemediateCopy.Arguments(threat));
        Assert.Contains("-ScanType 3", RemediateCopy.Arguments(threat));
        Assert.Contains(threat.Path, RemediateCopy.Arguments(threat));
    }
}
