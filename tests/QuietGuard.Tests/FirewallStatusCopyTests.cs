using QuietGuard;

namespace QuietGuard.Tests;

public class FirewallStatusCopyTests
{
    [Fact]
    public void OnOff_true_equals_text_and_is_on()
    {
        Assert.Equal("켜짐", FirewallStatusCopy.OnOff(true));
        Assert.Equal(FirewallStatusText.OnOff(true), FirewallStatusCopy.OnOff(true));
    }

    [Fact]
    public void OnOff_false_equals_text_and_is_off()
    {
        Assert.Equal("꺼짐", FirewallStatusCopy.OnOff(false));
        Assert.Equal(FirewallStatusText.OnOff(false), FirewallStatusCopy.OnOff(false));
    }

    [Fact]
    public void AllOn_matches_text()
    {
        Assert.True(FirewallStatusCopy.AllOn(true, true, true));
        Assert.False(FirewallStatusCopy.AllOn(true, true, false));
        Assert.Equal(
            FirewallStatusText.AllOn(true, true, true),
            FirewallStatusCopy.AllOn(true, true, true));
        Assert.Equal(
            FirewallStatusText.AllOn(true, true, false),
            FirewallStatusCopy.AllOn(true, true, false));
    }

    [Fact]
    public void Summarize_equals_text_and_contains_firewall()
    {
        var text = FirewallStatusCopy.Summarize(true, true, false);

        Assert.Equal(FirewallStatusText.Summarize(true, true, false), text);
        Assert.Contains("방화벽", text);
    }
}
