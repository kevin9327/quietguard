using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatSummaryCopyTests
{
    [Fact]
    public void Restore_summary_equals_plan_and_is_nonempty()
    {
        var threat = Sample();
        var expected = ThreatActions.Plan(ThreatActionKind.Restore, threat);
        Assert.Equal(expected.Summary, ThreatSummaryCopy.Summary(ThreatActionKind.Restore, threat));
        Assert.False(string.IsNullOrWhiteSpace(ThreatSummaryCopy.Summary(ThreatActionKind.Restore, threat)));
        Assert.True(ThreatSummaryCopy.NotifyUser(ThreatActionKind.Restore, threat));
        Assert.Equal(expected.NotifyUser, ThreatSummaryCopy.NotifyUser(ThreatActionKind.Restore, threat));
    }

    [Fact]
    public void Remediate_summary_equals_plan()
    {
        var threat = Sample();
        var expected = ThreatActions.Plan(ThreatActionKind.Remediate, threat);
        Assert.Equal(expected.Summary, ThreatSummaryCopy.Summary(ThreatActionKind.Remediate, threat));
        Assert.Equal(expected.NotifyUser, ThreatSummaryCopy.NotifyUser(ThreatActionKind.Remediate, threat));
    }

    private static ThreatInfo Sample() => new(
        Name: "Trojan:Win32/Test",
        Path: @"C:\Users\a\Downloads\payload.exe",
        State: "Quarantined",
        DetectedAt: DateTime.Now);
}
