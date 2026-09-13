using QuietGuard;

namespace QuietGuard.Tests;

public class QuickScanCopyTests
{
    [Fact]
    public void Button_matches_ScanKindLabels_quick_and_tray_menu()
    {
        Assert.Equal(ScanKindLabels.Name(ScanKind.Quick), QuickScanCopy.Button());
        Assert.Equal(TrayMenuLabels.QuickScan, QuickScanCopy.Button());
    }

    [Fact]
    public void Arguments_match_ScanTypeArgs_quick_and_scheduled_quick_scan()
    {
        Assert.Equal(ScanTypeArgs.For(ScanKind.Quick), QuickScanCopy.Arguments());
        Assert.Equal(ScanScheduler.MpCmdArgumentsForScheduledQuickScan(), QuickScanCopy.Arguments());
    }
}
