using QuietGuard;

namespace QuietGuard.Tests;

public class ElevationPlanCopyTests
{
    [Fact]
    public void Restore_plan_needs_admin_and_equals_policy()
    {
        var threat = Sample();
        var plan = ThreatActions.Plan(ThreatActionKind.Restore, threat);
        Assert.True(ElevationPlanCopy.NeedsAdmin(plan));
        Assert.Equal(ElevationPolicy.RequiresElevation(plan), ElevationPlanCopy.NeedsAdmin(plan));
        Assert.True(ElevationPlanCopy.NeedsAdmin(ThreatActionKind.Restore));
        Assert.Equal(
            ElevationPolicy.RequiresElevation(ThreatActionKind.Restore),
            ElevationPlanCopy.NeedsAdmin(ThreatActionKind.Restore));
    }

    [Fact]
    public void Remediate_does_not_need_admin()
    {
        var threat = Sample();
        var plan = ThreatActions.Plan(ThreatActionKind.Remediate, threat);
        Assert.False(ElevationPlanCopy.NeedsAdmin(plan));
        Assert.Equal(ElevationPolicy.RequiresElevation(plan), ElevationPlanCopy.NeedsAdmin(plan));
        Assert.False(ElevationPlanCopy.NeedsAdmin(ThreatActionKind.Remediate));
        Assert.Equal(
            ElevationPolicy.RequiresElevation(ThreatActionKind.Remediate),
            ElevationPlanCopy.NeedsAdmin(ThreatActionKind.Remediate));
    }

    private static ThreatInfo Sample() => new(
        Name: "Trojan:Win32/Test",
        Path: @"C:\Users\a\Downloads\payload.exe",
        State: "Quarantined",
        DetectedAt: DateTime.Now);
}
