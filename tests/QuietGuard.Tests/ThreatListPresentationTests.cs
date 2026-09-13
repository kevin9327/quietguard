using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatListPresentationTests
{
    [Fact]
    public void FormatRow_contains_name_and_path()
    {
        var threat = SampleThreat();

        var row = ThreatListPresentation.FormatRow(threat);

        Assert.Contains(threat.Name, row);
        Assert.Contains(threat.Path, row);
        Assert.Contains(threat.DetectedAt!.Value.ToLocalTime().ToString("MM-dd HH:mm"), row);
    }

    [Fact]
    public void FormatRow_uses_placeholder_when_detected_at_is_null()
    {
        var threat = SampleThreat() with { DetectedAt = null };

        var row = ThreatListPresentation.FormatRow(threat);

        Assert.Contains("--:--", row);
        Assert.Contains(threat.Name, row);
        Assert.Contains(threat.Path, row);
    }

    [Fact]
    public void IsSelectableIndex_is_false_for_invalid_indexes()
    {
        Assert.False(ThreatListPresentation.IsSelectableIndex(-1, 1));
        Assert.False(ThreatListPresentation.IsSelectableIndex(0, 0));
        Assert.True(ThreatListPresentation.IsSelectableIndex(0, 1));
    }

    [Fact]
    public void AvailableActions_includes_restore_and_remediate_when_path_is_present()
    {
        var threat = SampleThreat();

        var actions = ThreatListPresentation.AvailableActions(threat);

        Assert.Contains(ThreatActionKind.Restore, actions);
        Assert.Contains(ThreatActionKind.Remediate, actions);
        Assert.True(ThreatActions.CanAct(ThreatActionKind.Restore, threat));
        Assert.True(ThreatActions.CanAct(ThreatActionKind.Remediate, threat));
    }

    [Fact]
    public void AvailableActions_omits_restore_when_path_is_empty()
    {
        var threat = SampleThreat() with { Path = "" };

        var actions = ThreatListPresentation.AvailableActions(threat);

        Assert.DoesNotContain(ThreatActionKind.Restore, actions);
        Assert.False(ThreatActions.CanAct(ThreatActionKind.Restore, threat));
    }

    private static ThreatInfo SampleThreat() => new(
        Name: "Trojan:Win32/Test",
        Path: @"C:\Users\a\Downloads\payload.exe",
        State: "Quarantined",
        DetectedAt: DateTime.Now);
}
