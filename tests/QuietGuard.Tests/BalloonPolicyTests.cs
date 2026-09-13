using QuietGuard;

namespace QuietGuard.Tests;

public class BalloonPolicyTests
{
    private static readonly DateTime UtcNow = new(2026, 9, 13, 12, 0, 0, DateTimeKind.Utc);

    [Fact]
    public void Show_protected_is_false()
    {
        Assert.False(BalloonPolicy.Show(ProtectionLevel.Protected));
    }

    [Fact]
    public void Show_unprotected_is_true()
    {
        Assert.True(BalloonPolicy.Show(ProtectionLevel.Unprotected));
    }

    [Fact]
    public void Show_protected_due_scan_matches_Decide_quiet_policy()
    {
        var decision = ScanScheduler.Decide(
            UtcNow,
            null,
            ScanScheduler.DefaultInterval,
            ProtectionLevel.Protected);

        Assert.True(decision.ShouldScan);
        Assert.False(decision.NotifyUser);
        Assert.False(BalloonPolicy.Show(decision));
    }

    [Fact]
    public void ShowForMpCmd_matches_MpCmdExit_IsClean()
    {
        Assert.False(BalloonPolicy.ShowForMpCmd(0));
        Assert.Equal(!MpCmdExit.IsClean(0), BalloonPolicy.ShowForMpCmd(0));

        Assert.True(BalloonPolicy.ShowForMpCmd(2));
        Assert.Equal(!MpCmdExit.IsClean(2), BalloonPolicy.ShowForMpCmd(2));
    }
}
