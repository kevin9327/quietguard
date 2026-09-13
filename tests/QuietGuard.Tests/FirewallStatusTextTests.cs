using QuietGuard;

namespace QuietGuard.Tests;

public class FirewallStatusTextTests
{
    [Fact]
    public void OnOff_true_is_on()
    {
        Assert.Equal("켜짐", FirewallStatusText.OnOff(true));
    }

    [Fact]
    public void OnOff_false_is_off()
    {
        Assert.Equal("꺼짐", FirewallStatusText.OnOff(false));
    }

    [Fact]
    public void AllOn_is_true_when_every_profile_is_on()
    {
        Assert.True(FirewallStatusText.AllOn(true, true, true));
    }

    [Fact]
    public void AllOn_is_false_when_one_profile_is_off()
    {
        Assert.False(FirewallStatusText.AllOn(true, true, false));
    }

    [Fact]
    public void Summarize_includes_firewall_label_and_each_profile_word()
    {
        var text = FirewallStatusText.Summarize(true, true, false);

        Assert.Contains("방화벽", text);
        Assert.Contains(FirewallStatusText.OnOff(true), text);
        Assert.Contains(FirewallStatusText.OnOff(false), text);
        Assert.Equal(
            $"방화벽 도메인/개인/공용: {FirewallStatusText.OnOff(true)}/{FirewallStatusText.OnOff(true)}/{FirewallStatusText.OnOff(false)}",
            text);
    }
}
