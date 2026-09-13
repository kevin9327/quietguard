using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatCountCopyTests
{
    [Fact]
    public void Zero_is_none_and_equals_text()
    {
        Assert.Equal("최근 위협 없음", ThreatCountCopy.Format(0));
        Assert.Equal(ThreatCountText.Format(0), ThreatCountCopy.Format(0));
        Assert.Equal(ThreatCountText.Format((IReadOnlyCollection<ThreatInfo>?)null), ThreatCountCopy.Format(null));
    }

    [Fact]
    public void Two_is_two_cases()
    {
        Assert.Equal("최근 위협 2건", ThreatCountCopy.Format(2));
        Assert.Equal(ThreatCountText.Format(2), ThreatCountCopy.Format(2));
    }

    [Fact]
    public void Negative_clamps_like_text()
    {
        Assert.Equal(ThreatCountText.Format(-3), ThreatCountCopy.Format(-3));
        Assert.Equal("최근 위협 없음", ThreatCountCopy.Format(-3));
    }
}
