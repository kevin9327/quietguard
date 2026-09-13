using QuietGuard;

namespace QuietGuard.Tests;

public class AllowArgsCopyTests
{
    [Fact]
    public void For_matches_AllowThreatArgs_AllowCopy_and_ThreatActions_Plan()
    {
        var threat = new ThreatInfo("2147598187", @"C:\Users\a\Downloads\payload.exe", "Quarantined", DateTime.Now);
        var expected = ThreatActions.Plan(ThreatActionKind.Allow, threat).Arguments;
        Assert.Equal(expected, AllowArgsCopy.For(threat));
        Assert.Equal(AllowThreatArgs.For(threat), AllowArgsCopy.For(threat));
        Assert.Equal(AllowCopy.Arguments(threat), AllowArgsCopy.For(threat));
        Assert.Contains("Add-MpPreference", AllowArgsCopy.For(threat));
        Assert.Contains("2147598187", AllowArgsCopy.For(threat));
    }
}
