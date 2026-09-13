using QuietGuard;

namespace QuietGuard.Tests;

public class FirewallHeadlineCopyTests
{
    [Fact]
    public void OnOff_true_equals_copy_and_text_and_is_on()
    {
        Assert.Equal("켜짐", FirewallHeadlineCopy.OnOff(true));
        Assert.Equal(FirewallStatusCopy.OnOff(true), FirewallHeadlineCopy.OnOff(true));
        Assert.Equal(FirewallStatusText.OnOff(true), FirewallHeadlineCopy.OnOff(true));
    }

    [Fact]
    public void OnOff_false_equals_copy_and_text_and_is_off()
    {
        Assert.Equal("꺼짐", FirewallHeadlineCopy.OnOff(false));
        Assert.Equal(FirewallStatusCopy.OnOff(false), FirewallHeadlineCopy.OnOff(false));
        Assert.Equal(FirewallStatusText.OnOff(false), FirewallHeadlineCopy.OnOff(false));
    }

    [Fact]
    public void AllOn_matches_copy_and_text()
    {
        Assert.True(FirewallHeadlineCopy.AllOn(true, true, true));
        Assert.False(FirewallHeadlineCopy.AllOn(true, true, false));
        Assert.Equal(
            FirewallStatusCopy.AllOn(true, true, true),
            FirewallHeadlineCopy.AllOn(true, true, true));
        Assert.Equal(
            FirewallStatusText.AllOn(true, true, true),
            FirewallHeadlineCopy.AllOn(true, true, true));
        Assert.Equal(
            FirewallStatusCopy.AllOn(true, true, false),
            FirewallHeadlineCopy.AllOn(true, true, false));
        Assert.Equal(
            FirewallStatusText.AllOn(true, true, false),
            FirewallHeadlineCopy.AllOn(true, true, false));
    }

    [Fact]
    public void Summarize_equals_copy_and_text_and_contains_firewall()
    {
        var text = FirewallHeadlineCopy.Summarize(true, true, false);

        Assert.Equal(FirewallStatusCopy.Summarize(true, true, false), text);
        Assert.Equal(FirewallStatusText.Summarize(true, true, false), text);
        Assert.Contains("방화벽", text);
    }
}
