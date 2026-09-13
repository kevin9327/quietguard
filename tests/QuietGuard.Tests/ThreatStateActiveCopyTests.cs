using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatStateActiveCopyTests
{
    [Fact]
    public void Active_is_active_and_equals_describe()
    {
        Assert.Equal("활성", ThreatStateActiveCopy.Active());
        Assert.Equal(ThreatStateText.Describe("Active"), ThreatStateActiveCopy.Active());
        Assert.Equal(ThreatStateText.Describe("1"), ThreatStateActiveCopy.Active());
    }

    [Fact]
    public void Removed_is_removed_and_equals_describe()
    {
        Assert.Equal("제거됨", ThreatStateActiveCopy.Removed());
        Assert.Equal(ThreatStateText.Describe("Removed"), ThreatStateActiveCopy.Removed());
        Assert.Equal(ThreatStateText.Describe("3"), ThreatStateActiveCopy.Removed());
    }

    [Fact]
    public void Quarantined_is_isolated_and_equals_describe()
    {
        Assert.Equal("격리됨", ThreatStateActiveCopy.Quarantined());
        Assert.Equal(ThreatStateText.Describe("Quarantined"), ThreatStateActiveCopy.Quarantined());
        Assert.Equal(ThreatStateText.Describe("6"), ThreatStateActiveCopy.Quarantined());
    }
}
