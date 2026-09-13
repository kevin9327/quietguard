using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatOrderCopyTests
{
    [Fact]
    public void Preferred_is_restore_allow_remediate_in_that_order()
    {
        Assert.Equal(
            [
                ThreatActionKind.Restore,
                ThreatActionKind.Allow,
                ThreatActionKind.Remediate
            ],
            ThreatOrderCopy.Preferred);
        Assert.Equal(ThreatActionOrder.Preferred, ThreatOrderCopy.Preferred);
    }

    [Fact]
    public void For_path_bearing_threat_equals_AvailableActions()
    {
        var threat = SampleThreat();

        var ordered = ThreatOrderCopy.For(threat);

        Assert.Equal(ThreatActionOrder.For(threat), ordered);
        Assert.Equal(ThreatListPresentation.AvailableActions(threat), ordered);
    }

    [Fact]
    public void For_empty_path_does_not_include_restore()
    {
        var threat = SampleThreat() with { Path = "" };

        var ordered = ThreatOrderCopy.For(threat);

        Assert.DoesNotContain(ThreatActionKind.Restore, ordered);
    }

    private static ThreatInfo SampleThreat() => new(
        Name: "Trojan:Win32/Test",
        Path: @"C:\Users\a\Downloads\payload.exe",
        State: "Quarantined",
        DetectedAt: DateTime.Now);
}
