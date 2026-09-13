using QuietGuard;

namespace QuietGuard.Tests;

public class ElevationPolicyTests
{
    [Theory]
    [InlineData(ThreatActionKind.Restore)]
    [InlineData(ThreatActionKind.Allow)]
    [InlineData(ThreatActionKind.Remediate)]
    public void RequiresElevation_matches_ThreatActions_Plan(ThreatActionKind kind)
    {
        var threat = new ThreatInfo(
            Name: "Trojan:Win32/Test",
            Path: @"C:\Users\a\Downloads\payload.exe",
            State: "Quarantined",
            DetectedAt: DateTime.Now);

        var plan = ThreatActions.Plan(kind, threat);

        Assert.Equal(plan.RequiresElevation, ElevationPolicy.RequiresElevation(kind));
        Assert.Equal(plan.RequiresElevation, ElevationPolicy.RequiresElevation(plan));
    }
}
