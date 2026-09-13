using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatCountHeadlineCopyTests
{
    [Fact]
    public void Zero_is_none()
    {
        Assert.Equal("최근 위협 없음", ThreatCountHeadlineCopy.Format(0));
        Assert.Equal(ThreatCountCopy.Format(0), ThreatCountHeadlineCopy.Format(0));
        Assert.Equal(ThreatCountText.Format(0), ThreatCountHeadlineCopy.Format(0));
    }

    [Fact]
    public void Two_is_two_cases()
    {
        Assert.Equal("최근 위협 2건", ThreatCountHeadlineCopy.Format(2));
        Assert.Equal(ThreatCountCopy.Format(2), ThreatCountHeadlineCopy.Format(2));
        Assert.Equal(ThreatCountText.Format(2), ThreatCountHeadlineCopy.Format(2));
    }
}
