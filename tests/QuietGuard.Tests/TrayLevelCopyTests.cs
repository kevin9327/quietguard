using QuietGuard;

namespace QuietGuard.Tests;

public class TrayLevelCopyTests
{
    [Fact]
    public void Protected_headline_equals_tooltip_format()
    {
        const string headline = "보호 중";
        Assert.Equal(TrayTooltip.Format(ProtectionLevel.Protected, headline), TrayLevelCopy.Format(ProtectionLevel.Protected, headline));
        Assert.Contains("QuietGuard", TrayLevelCopy.Format(ProtectionLevel.Protected, headline));
        Assert.Contains(headline, TrayLevelCopy.Format(ProtectionLevel.Protected, headline));
    }

    [Fact]
    public void Verdict_overload_equals_tray_tooltip()
    {
        var verdict = new ProtectionVerdict(ProtectionLevel.Unprotected, "보호되지 않음", Array.Empty<string>());
        Assert.Equal(TrayTooltip.Format(verdict), TrayLevelCopy.Format(verdict));
        Assert.Equal(
            TrayTooltip.Format(ProtectionLevel.Unprotected, "보호되지 않음"),
            TrayLevelCopy.Format(verdict));
    }
}
