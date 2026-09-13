using QuietGuard;

namespace QuietGuard.Tests;

public class TrayTooltipTests
{
    [Fact]
    public void Format_protected_contains_quietguard_and_headline()
    {
        var text = TrayTooltip.Format(ProtectionLevel.Protected, "보호 중");

        Assert.Contains("QuietGuard", text);
        Assert.Contains("보호 중", text);
    }

    [Fact]
    public void Clamp_100_char_string_is_63()
    {
        Assert.Equal(63, TrayTooltip.Clamp(new string('x', 100)).Length);
    }

    [Fact]
    public void Clamp_empty_is_quietguard()
    {
        Assert.Equal("QuietGuard", TrayTooltip.Clamp(string.Empty));
    }

    [Fact]
    public void Format_verdict_equals_format_level_headline()
    {
        var verdict = new ProtectionVerdict(
            ProtectionLevel.Protected,
            "보호 중",
            Array.Empty<string>());

        Assert.Equal(
            TrayTooltip.Format(verdict.Level, verdict.Headline),
            TrayTooltip.Format(verdict));
    }
}
