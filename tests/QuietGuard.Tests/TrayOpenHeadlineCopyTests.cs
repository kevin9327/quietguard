using QuietGuard;

namespace QuietGuard.Tests;

public class TrayOpenHeadlineCopyTests
{
    [Fact]
    public void Menu_is_open_and_equals_tray_open_copy()
    {
        Assert.Equal("열기", TrayOpenHeadlineCopy.Menu());
        Assert.Equal(TrayOpenCopy.Menu(), TrayOpenHeadlineCopy.Menu());
        Assert.Equal(TrayMenuLabels.Open, TrayOpenHeadlineCopy.Menu());
    }

    [Fact]
    public void Exit_is_exit_and_equals_tray_open_copy()
    {
        Assert.Equal("종료", TrayOpenHeadlineCopy.Exit());
        Assert.Equal(TrayOpenCopy.Exit(), TrayOpenHeadlineCopy.Exit());
        Assert.Equal(TrayMenuLabels.Exit, TrayOpenHeadlineCopy.Exit());
    }
}
