using QuietGuard;

namespace QuietGuard.Tests;

public class BalloonShowHeadlineCopyTests
{
    [Fact]
    public void Protected_does_not_show()
    {
        Assert.False(BalloonShowHeadlineCopy.Show(ProtectionLevel.Protected));
        Assert.Equal(BalloonShowCopy.Show(ProtectionLevel.Protected), BalloonShowHeadlineCopy.Show(ProtectionLevel.Protected));
        Assert.Equal(BalloonPolicy.Show(ProtectionLevel.Protected), BalloonShowHeadlineCopy.Show(ProtectionLevel.Protected));
    }

    [Fact]
    public void Unprotected_shows_and_mpcmd_threat_shows()
    {
        Assert.True(BalloonShowHeadlineCopy.Show(ProtectionLevel.Unprotected));
        Assert.Equal(BalloonShowCopy.Show(ProtectionLevel.Unprotected), BalloonShowHeadlineCopy.Show(ProtectionLevel.Unprotected));
        Assert.False(BalloonShowHeadlineCopy.ShowForMpCmd(0));
        Assert.True(BalloonShowHeadlineCopy.ShowForMpCmd(2));
        Assert.Equal(BalloonShowCopy.ShowForMpCmd(2), BalloonShowHeadlineCopy.ShowForMpCmd(2));
        Assert.Equal(BalloonPolicy.ShowForMpCmd(2), BalloonShowHeadlineCopy.ShowForMpCmd(2));
    }
}
