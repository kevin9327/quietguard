using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatStateHeadlineCopyTests
{
    [Fact]
    public void Headline_quarantined_id_equals_describe_isolated()
    {
        Assert.Equal("격리됨", ThreatStateHeadlineCopy.Headline("6"));
        Assert.Equal(ThreatStateCopy.Headline("6"), ThreatStateHeadlineCopy.Headline("6"));
        Assert.Equal(ThreatStateText.Describe("6"), ThreatStateHeadlineCopy.Headline("6"));
    }

    [Fact]
    public void Headline_quarantined_word_equals_describe()
    {
        Assert.Equal("격리됨", ThreatStateHeadlineCopy.Headline("Quarantined"));
        Assert.Equal(
            ThreatStateCopy.Headline("Quarantined"),
            ThreatStateHeadlineCopy.Headline("Quarantined"));
        Assert.Equal(
            ThreatStateText.Describe("Quarantined"),
            ThreatStateHeadlineCopy.Headline("Quarantined"));
    }

    [Fact]
    public void ThreatInfo_overload_matches_Describe()
    {
        var threat = Sample("6");

        Assert.Equal("격리됨", ThreatStateHeadlineCopy.Headline(threat));
        Assert.Equal(ThreatStateCopy.Headline(threat), ThreatStateHeadlineCopy.Headline(threat));
        Assert.Equal(ThreatStateText.Describe(threat), ThreatStateHeadlineCopy.Headline(threat));
        Assert.Equal(ThreatStateText.Describe(threat.State), ThreatStateHeadlineCopy.Headline(threat));
        Assert.Equal(ThreatStateCopy.Headline(threat.State), ThreatStateHeadlineCopy.Headline(threat));
        Assert.Equal(ThreatStateHeadlineCopy.Headline(threat.State), ThreatStateHeadlineCopy.Headline(threat));
    }

    [Fact]
    public void Headline_null_is_none()
    {
        Assert.Equal("상태 없음", ThreatStateHeadlineCopy.Headline((string?)null));
        Assert.Equal(
            ThreatStateCopy.Headline((string?)null),
            ThreatStateHeadlineCopy.Headline((string?)null));
        Assert.Equal(
            ThreatStateText.Describe((string?)null),
            ThreatStateHeadlineCopy.Headline((string?)null));
    }

    private static ThreatInfo Sample(string? state) => new(
        Name: "Trojan:Win32/Test",
        Path: @"C:\Users\a\Downloads\payload.exe",
        State: state!,
        DetectedAt: DateTime.Now);
}
