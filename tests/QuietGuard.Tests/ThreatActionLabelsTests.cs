using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatActionLabelsTests
{
    [Fact]
    public void Button_maps_restore_to_korean_label()
    {
        Assert.Equal("복원", ThreatActionLabels.Button(ThreatActionKind.Restore));
    }

    [Fact]
    public void Button_maps_allow_to_korean_label()
    {
        Assert.Equal("허용", ThreatActionLabels.Button(ThreatActionKind.Allow));
    }

    [Fact]
    public void Button_maps_remediate_to_korean_label()
    {
        Assert.Equal("치료 검사", ThreatActionLabels.Button(ThreatActionKind.Remediate));
    }

    [Fact]
    public void Button_falls_back_to_ToString_for_undefined_kind()
    {
        var undefined = (ThreatActionKind)999;

        Assert.Equal(undefined.ToString(), ThreatActionLabels.Button(undefined));
    }
}
