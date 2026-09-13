using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatListCopyTests
{
    [Fact]
    public void Placeholder_equals_empty_list_placeholder()
    {
        Assert.Equal(ThreatListPresentation.EmptyListPlaceholder, ThreatListCopy.Placeholder());
        Assert.Equal("최근 위협 없음", ThreatListCopy.Placeholder());
    }

    [Fact]
    public void FormatRow_contains_name_and_path()
    {
        var threat = SampleThreat();

        var row = ThreatListCopy.FormatRow(threat);

        Assert.Contains(threat.Name, row);
        Assert.Contains(threat.Path, row);
        Assert.Contains(threat.DetectedAt!.Value.ToLocalTime().ToString("MM-dd HH:mm"), row);
        Assert.Equal(ThreatListPresentation.FormatRow(threat), row);
    }

    [Fact]
    public void FormatRow_uses_placeholder_when_detected_at_is_null()
    {
        var threat = SampleThreat() with { DetectedAt = null };

        var row = ThreatListCopy.FormatRow(threat);

        Assert.Contains("--:--", row);
        Assert.Equal(ThreatListPresentation.FormatRow(threat), row);
    }

    [Fact]
    public void IsSelectable_matches_IsSelectableIndex()
    {
        Assert.False(ThreatListCopy.IsSelectable(-1, 1));
        Assert.False(ThreatListCopy.IsSelectable(0, 0));
        Assert.True(ThreatListCopy.IsSelectable(0, 1));
        Assert.Equal(ThreatListPresentation.IsSelectableIndex(-1, 1), ThreatListCopy.IsSelectable(-1, 1));
        Assert.Equal(ThreatListPresentation.IsSelectableIndex(0, 0), ThreatListCopy.IsSelectable(0, 0));
        Assert.Equal(ThreatListPresentation.IsSelectableIndex(0, 1), ThreatListCopy.IsSelectable(0, 1));
    }

    private static ThreatInfo SampleThreat() => new(
        Name: "Trojan:Win32/Test",
        Path: @"C:\Users\a\Downloads\payload.exe",
        State: "Quarantined",
        DetectedAt: DateTime.Now);
}
