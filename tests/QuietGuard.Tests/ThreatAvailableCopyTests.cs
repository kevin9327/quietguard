using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatAvailableCopyTests
{
    [Fact]
    public void Available_path_bearing_threat_equals_AvailableActions()
    {
        var threat = SampleThreat();

        var available = ThreatAvailableCopy.Available(threat);

        Assert.Equal(ThreatListPresentation.AvailableActions(threat), available);
        Assert.Equal(ThreatOrderCopy.For(threat), available);
        Assert.Contains(ThreatActionKind.Restore, available);
    }

    [Fact]
    public void Available_empty_path_does_not_include_restore()
    {
        var threat = SampleThreat() with { Path = "" };

        var available = ThreatAvailableCopy.Available(threat);

        Assert.DoesNotContain(ThreatActionKind.Restore, available);
        Assert.Equal(ThreatListPresentation.AvailableActions(threat), available);
    }

    private static ThreatInfo SampleThreat() => new(
        Name: "Trojan:Win32/Test",
        Path: @"C:\Users\a\Downloads\payload.exe",
        State: "Quarantined",
        DetectedAt: DateTime.Now);
}
