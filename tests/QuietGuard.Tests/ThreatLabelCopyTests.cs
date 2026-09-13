using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatLabelCopyTests
{
    [Fact]
    public void Button_matches_threat_action_labels()
    {
        Assert.Equal(ThreatActionLabels.Button(ThreatActionKind.Restore), ThreatLabelCopy.Button(ThreatActionKind.Restore));
        Assert.Equal(ThreatActionLabels.Button(ThreatActionKind.Allow), ThreatLabelCopy.Button(ThreatActionKind.Allow));
        Assert.Equal(ThreatActionLabels.Button(ThreatActionKind.Remediate), ThreatLabelCopy.Button(ThreatActionKind.Remediate));
        Assert.Equal("복원", ThreatLabelCopy.Button(ThreatActionKind.Restore));
        Assert.Equal("허용", ThreatLabelCopy.Button(ThreatActionKind.Allow));
        Assert.Equal("치료 검사", ThreatLabelCopy.Button(ThreatActionKind.Remediate));
    }

    [Fact]
    public void Restore_matches_threat_action_label()
    {
        Assert.Equal(ThreatActionLabels.Button(ThreatActionKind.Restore), ThreatLabelCopy.Restore());
        Assert.Equal("복원", ThreatLabelCopy.Restore());
    }

    [Fact]
    public void Allow_matches_threat_action_label()
    {
        Assert.Equal(ThreatActionLabels.Button(ThreatActionKind.Allow), ThreatLabelCopy.Allow());
        Assert.Equal("허용", ThreatLabelCopy.Allow());
    }

    [Fact]
    public void Remediate_matches_threat_action_label()
    {
        Assert.Equal(ThreatActionLabels.Button(ThreatActionKind.Remediate), ThreatLabelCopy.Remediate());
        Assert.Equal("치료 검사", ThreatLabelCopy.Remediate());
    }

    [Fact]
    public void Button_falls_back_to_ToString_for_undefined_kind()
    {
        var undefined = (ThreatActionKind)999;

        Assert.Equal(undefined.ToString(), ThreatLabelCopy.Button(undefined));
        Assert.Equal(ThreatActionLabels.Button(undefined), ThreatLabelCopy.Button(undefined));
    }
}
