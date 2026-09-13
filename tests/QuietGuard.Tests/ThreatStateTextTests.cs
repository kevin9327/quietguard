using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatStateTextTests
{
    [Fact]
    public void Describe_quarantined_word_is_isolated()
    {
        Assert.Equal("격리됨", ThreatStateText.Describe("Quarantined"));
        AssertStringAndThreatOverloadsMatch("Quarantined");
    }

    [Fact]
    public void Describe_quarantined_id_is_isolated()
    {
        Assert.Equal("격리됨", ThreatStateText.Describe("6"));
        AssertStringAndThreatOverloadsMatch("6");
    }

    [Fact]
    public void Describe_active_word_is_active()
    {
        Assert.Equal("활성", ThreatStateText.Describe("Active"));
        AssertStringAndThreatOverloadsMatch("Active");
    }

    [Fact]
    public void Describe_active_id_is_active()
    {
        Assert.Equal("활성", ThreatStateText.Describe("1"));
        AssertStringAndThreatOverloadsMatch("1");
    }

    [Fact]
    public void Describe_removed_word_is_removed()
    {
        Assert.Equal("제거됨", ThreatStateText.Describe("Removed"));
        AssertStringAndThreatOverloadsMatch("Removed");
    }

    [Fact]
    public void Describe_removed_id_is_removed()
    {
        Assert.Equal("제거됨", ThreatStateText.Describe("3"));
        AssertStringAndThreatOverloadsMatch("3");
    }

    [Fact]
    public void Describe_null_is_none()
    {
        Assert.Equal("상태 없음", ThreatStateText.Describe((string?)null));
        AssertStringAndThreatOverloadsMatch(null);
    }

    [Fact]
    public void Describe_whitespace_is_none()
    {
        Assert.Equal("상태 없음", ThreatStateText.Describe(""));
        Assert.Equal("상태 없음", ThreatStateText.Describe("   "));
        AssertStringAndThreatOverloadsMatch("");
        AssertStringAndThreatOverloadsMatch("   ");
    }

    [Fact]
    public void Describe_unknown_returns_original()
    {
        Assert.Equal("xyz", ThreatStateText.Describe("xyz"));
        AssertStringAndThreatOverloadsMatch("xyz");
    }

    private static void AssertStringAndThreatOverloadsMatch(string? state)
    {
        var threat = Sample(state);

        Assert.Equal(
            ThreatStateText.Describe(state),
            ThreatStateText.Describe(threat));
    }

    private static ThreatInfo Sample(string? state) => new(
        Name: "Trojan:Win32/Test",
        Path: @"C:\Users\a\Downloads\payload.exe",
        State: state!,
        DetectedAt: DateTime.Now);
}
