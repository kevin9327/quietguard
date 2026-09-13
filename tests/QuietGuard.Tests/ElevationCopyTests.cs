using QuietGuard;

namespace QuietGuard.Tests;

public class ElevationCopyTests
{
    [Fact]
    public void Restore_NeedsAdmin_matches_ElevationPolicy_and_Plan()
    {
        var threat = new ThreatInfo(
            Name: "Trojan:Win32/Test",
            Path: @"C:\Users\a\Downloads\payload.exe",
            State: "Quarantined",
            DetectedAt: DateTime.Now);

        var plan = ThreatActions.Plan(ThreatActionKind.Restore, threat);

        Assert.True(ElevationCopy.NeedsAdmin(ThreatActionKind.Restore));
        Assert.Equal(
            ElevationPolicy.RequiresElevation(ThreatActionKind.Restore),
            ElevationCopy.NeedsAdmin(ThreatActionKind.Restore));
        Assert.Equal(plan.RequiresElevation, ElevationCopy.NeedsAdmin(ThreatActionKind.Restore));
    }

    [Fact]
    public void Remediate_NeedsAdmin_is_false()
    {
        Assert.False(ElevationCopy.NeedsAdmin(ThreatActionKind.Remediate));
    }

    [Fact]
    public void Restore_headline_requires_admin()
    {
        Assert.Equal("관리자 권한 필요", ElevationCopy.Headline(ThreatActionKind.Restore));
    }

    [Fact]
    public void Remediate_headline_is_standard_privilege()
    {
        Assert.Equal("일반 권한으로 실행", ElevationCopy.Headline(ThreatActionKind.Remediate));
    }
}
