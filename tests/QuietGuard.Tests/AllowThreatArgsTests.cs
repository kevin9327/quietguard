using QuietGuard;

namespace QuietGuard.Tests;

public class AllowThreatArgsTests
{
    [Fact]
    public void For_matches_ThreatActions_Plan_allow_arguments()
    {
        var threat = new ThreatInfo("2147598187", @"C:\Users\a\Downloads\payload.exe", "6", DateTime.Now);
        var expected = ThreatActions.Plan(ThreatActionKind.Allow, threat).Arguments;
        Assert.Equal(expected, AllowThreatArgs.For(threat));
        Assert.Contains("Add-MpPreference", expected);
        Assert.Contains("2147598187", AllowThreatArgs.For(threat));
    }

    [Fact]
    public void For_empty_threat_throws_like_Plan()
    {
        var empty = new ThreatInfo("", "", "", null);
        Assert.Throws<ArgumentException>(() => AllowThreatArgs.For(empty));
    }
}
