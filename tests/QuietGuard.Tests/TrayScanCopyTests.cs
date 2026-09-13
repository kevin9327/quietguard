using QuietGuard;

namespace QuietGuard.Tests;

public class TrayScanCopyTests
{
    [Fact]
    public void QuickScan_matches_tray_quick_scan_label()
    {
        Assert.Equal(TrayMenuLabels.QuickScan, TrayScanCopy.QuickScan());
        Assert.Equal("빠른 검사", TrayScanCopy.QuickScan());
    }

    [Fact]
    public void UpdateDefinitions_matches_tray_update_definitions_label()
    {
        Assert.Equal(TrayMenuLabels.UpdateDefinitions, TrayScanCopy.UpdateDefinitions());
        Assert.Equal("정의 업데이트", TrayScanCopy.UpdateDefinitions());
    }
}
