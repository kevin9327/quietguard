using QuietGuard;

namespace QuietGuard.Tests;

public class AllowCopyTests
{
    [Fact]
    public void Button_matches_threat_action_label_and_preference_allow_name()
    {
        Assert.Equal(ThreatActionLabels.Button(ThreatActionKind.Allow), AllowCopy.Button());
        Assert.Equal(PreferenceActionText.Name(6), AllowCopy.Button());
        Assert.Equal("허용", AllowCopy.Button());
    }

    [Fact]
    public void Arguments_match_AllowThreatArgs_and_ThreatActions_Plan()
    {
        var threat = new ThreatInfo("2147598187", @"C:\Users\a\Downloads\payload.exe", "6", DateTime.Now);
        var expected = ThreatActions.Plan(ThreatActionKind.Allow, threat).Arguments;
        Assert.Equal(expected, AllowCopy.Arguments(threat));
        Assert.Equal(AllowThreatArgs.For(threat), AllowCopy.Arguments(threat));
    }

    [Fact]
    public void ActionId_matches_PreferenceActionText_AllowId()
    {
        Assert.Equal(PreferenceActionText.AllowId, AllowCopy.ActionId);
    }
}
