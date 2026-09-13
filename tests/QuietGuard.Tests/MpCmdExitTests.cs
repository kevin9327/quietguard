using QuietGuard;

namespace QuietGuard.Tests;

public class MpCmdExitTests
{
    [Fact]
    public void Zero_is_clean_not_threat()
    {
        Assert.True(MpCmdExit.IsClean(0));
        Assert.False(MpCmdExit.IsThreatDetected(0));
    }

    [Fact]
    public void Two_is_threat_not_clean()
    {
        Assert.True(MpCmdExit.IsThreatDetected(2));
        Assert.False(MpCmdExit.IsClean(2));
    }

    [Fact]
    public void One_is_neither_clean_nor_threat()
    {
        Assert.False(MpCmdExit.IsClean(1));
        Assert.False(MpCmdExit.IsThreatDetected(1));
    }

    [Fact]
    public void Describe_maps_known_and_unknown_codes()
    {
        Assert.Equal("이상 없음", MpCmdExit.Describe(0));
        Assert.Equal("위협 발견", MpCmdExit.Describe(2));
        Assert.Equal("종료 코드 1", MpCmdExit.Describe(1));
    }
}
