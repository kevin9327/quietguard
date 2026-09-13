using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatCountTextTests
{
    [Fact]
    public void Format_zero_equals_empty_list_placeholder()
    {
        Assert.Equal(ThreatListPresentation.EmptyListPlaceholder, ThreatCountText.Format(0));
    }

    [Fact]
    public void Format_two_contains_count()
    {
        Assert.Contains("2", ThreatCountText.Format(2));
    }

    [Fact]
    public void Format_null_collection_is_same_as_zero()
    {
        Assert.Equal(
            ThreatCountText.Format(0),
            ThreatCountText.Format((IReadOnlyCollection<ThreatInfo>?)null));
    }

    [Fact]
    public void Format_negative_is_treated_as_zero()
    {
        Assert.Equal(ThreatCountText.Format(0), ThreatCountText.Format(-1));
    }

    [Fact]
    public void Format_collection_uses_real_threat_count()
    {
        IReadOnlyCollection<ThreatInfo> threats =
        [
            new ThreatInfo("Trojan:Win32/TestA", @"C:\Users\a\Downloads\a.exe", "Quarantined", DateTime.Now),
            new ThreatInfo("Trojan:Win32/TestB", @"C:\Users\a\Downloads\b.exe", "Quarantined", DateTime.Now)
        ];

        var text = ThreatCountText.Format(threats);

        Assert.Contains("2", text);
        Assert.Equal(ThreatCountText.Format(2), text);
    }
}
