using QuietGuard;

namespace QuietGuard.Tests;

public class TrayOpenCopyTests
{
    [Fact]
    public void Menu_matches_tray_open_label()
    {
        Assert.Equal(TrayMenuLabels.Open, TrayOpenCopy.Menu());
        Assert.Equal("열기", TrayOpenCopy.Menu());
    }

    [Fact]
    public void Exit_matches_tray_exit_label()
    {
        Assert.Equal(TrayMenuLabels.Exit, TrayOpenCopy.Exit());
        Assert.Equal("종료", TrayOpenCopy.Exit());
    }

    [Fact]
    public void Tooltip_matches_TrayTooltip_for_protected_verdict()
    {
        var verdict = new ProtectionVerdict(
            ProtectionLevel.Protected,
            "보호 중",
            Array.Empty<string>());

        Assert.Equal(TrayTooltip.Format(verdict), TrayOpenCopy.Tooltip(verdict));
    }
}
