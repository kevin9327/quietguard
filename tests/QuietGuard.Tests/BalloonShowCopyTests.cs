using QuietGuard;

namespace QuietGuard.Tests;

public class BalloonShowCopyTests
{
    [Fact]
    public void Protected_does_not_show_and_equals_policy()
    {
        Assert.False(BalloonShowCopy.Show(ProtectionLevel.Protected));
        Assert.Equal(BalloonPolicy.Show(ProtectionLevel.Protected), BalloonShowCopy.Show(ProtectionLevel.Protected));
    }

    [Fact]
    public void Unprotected_shows_and_equals_policy()
    {
        Assert.True(BalloonShowCopy.Show(ProtectionLevel.Unprotected));
        Assert.Equal(BalloonPolicy.Show(ProtectionLevel.Unprotected), BalloonShowCopy.Show(ProtectionLevel.Unprotected));
    }

    [Fact]
    public void Quiet_scheduled_scan_does_not_show()
    {
        var quiet = new ScanScheduleDecision(true, false, "보호 중이므로 조용히 검사합니다.");
        Assert.False(BalloonShowCopy.Show(quiet));
        Assert.Equal(BalloonPolicy.Show(quiet), BalloonShowCopy.Show(quiet));
    }

    [Fact]
    public void MpCmd_clean_does_not_show_threat_does()
    {
        Assert.False(BalloonShowCopy.ShowForMpCmd(0));
        Assert.True(BalloonShowCopy.ShowForMpCmd(2));
        Assert.Equal(BalloonPolicy.ShowForMpCmd(0), BalloonShowCopy.ShowForMpCmd(0));
        Assert.Equal(BalloonPolicy.ShowForMpCmd(2), BalloonShowCopy.ShowForMpCmd(2));
    }
}
