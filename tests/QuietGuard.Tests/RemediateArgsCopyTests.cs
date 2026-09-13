using QuietGuard;

namespace QuietGuard.Tests;

public class RemediateArgsCopyTests
{
    [Fact]
    public void Button_equals_remediate_copy_and_label()
    {
        Assert.Equal("치료 검사", RemediateArgsCopy.Button());
        Assert.Equal(RemediateCopy.Button(), RemediateArgsCopy.Button());
        Assert.Equal(ThreatActionLabels.Button(ThreatActionKind.Remediate), RemediateArgsCopy.Button());
    }

    [Fact]
    public void Arguments_match_RemediateCopy_and_ThreatActions_Plan()
    {
        var threat = new ThreatInfo("Trojan:Win32/Test", @"C:\Users\a\Downloads\payload.exe", "Quarantined", DateTime.Now);
        var expected = ThreatActions.Plan(ThreatActionKind.Remediate, threat).Arguments;
        Assert.Equal(expected, RemediateArgsCopy.Arguments(threat));
        Assert.Equal(RemediateCopy.Arguments(threat), RemediateArgsCopy.Arguments(threat));
        Assert.Contains("-Scan", RemediateArgsCopy.Arguments(threat));
        Assert.Contains("-ScanType 3", RemediateArgsCopy.Arguments(threat));
        Assert.Contains($"\"{threat.Path}\"", RemediateArgsCopy.Arguments(threat));
    }
}
