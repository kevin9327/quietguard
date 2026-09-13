using QuietGuard;

namespace QuietGuard.Tests;

public class MpCmdThreatCopyTests
{
    [Fact]
    public void IsThreatDetected_two_true_zero_false_matches_MpCmdExit()
    {
        Assert.True(MpCmdThreatCopy.IsThreatDetected(2));
        Assert.False(MpCmdThreatCopy.IsThreatDetected(0));
        Assert.Equal(MpCmdExit.IsThreatDetected(2), MpCmdThreatCopy.IsThreatDetected(2));
        Assert.Equal(MpCmdExit.IsThreatDetected(0), MpCmdThreatCopy.IsThreatDetected(0));
    }

    [Fact]
    public void Headline_two_equals_threat_found_and_MpCmdExit_Describe()
    {
        Assert.Equal("위협 발견", MpCmdThreatCopy.Headline(2));
        Assert.Equal(MpCmdExit.Describe(2), MpCmdThreatCopy.Headline(2));
    }

    [Fact]
    public void Headline_zero_equals_no_issue()
    {
        Assert.Equal("이상 없음", MpCmdThreatCopy.Headline(0));
    }

    [Fact]
    public void Headline_seven_equals_exit_code_seven()
    {
        Assert.Equal("종료 코드 7", MpCmdThreatCopy.Headline(7));
    }
}
