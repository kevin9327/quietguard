using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatStateCopyTests
{
    [Fact]
    public void Headline_quarantined_id_equals_describe_isolated()
    {
        Assert.Equal("격리됨", ThreatStateCopy.Headline("6"));
        Assert.Equal(ThreatStateText.Describe("6"), ThreatStateCopy.Headline("6"));
    }

    [Fact]
    public void Headline_quarantined_word_equals_describe()
    {
        Assert.Equal("격리됨", ThreatStateCopy.Headline("Quarantined"));
        Assert.Equal(
            ThreatStateText.Describe("Quarantined"),
            ThreatStateCopy.Headline("Quarantined"));
    }

    [Fact]
    public void ThreatInfo_overload_matches_Describe()
    {
        var threat = Sample("6");

        Assert.Equal(ThreatStateText.Describe(threat), ThreatStateCopy.Headline(threat));
        Assert.Equal(ThreatStateText.Describe(threat.State), ThreatStateCopy.Headline(threat));
        Assert.Equal(ThreatStateCopy.Headline(threat.State), ThreatStateCopy.Headline(threat));
    }

    [Fact]
    public void Headline_null_is_none()
    {
        Assert.Equal("상태 없음", ThreatStateCopy.Headline((string?)null));
        Assert.Equal(
            ThreatStateText.Describe((string?)null),
            ThreatStateCopy.Headline((string?)null));
    }

    private static ThreatInfo Sample(string? state) => new(
        Name: "Trojan:Win32/Test",
        Path: @"C:\Users\a\Downloads\payload.exe",
        State: state!,
        DetectedAt: DateTime.Now);
}
