using QuietGuard;

namespace QuietGuard.Tests;

public class QuickScanHeadlineCopyTests
{
    [Fact]
    public void Button_is_quick_scan_and_equals_copy()
    {
        Assert.Equal("빠른 검사", QuickScanHeadlineCopy.Button());
        Assert.Equal(QuickScanCopy.Button(), QuickScanHeadlineCopy.Button());
        Assert.Equal(ScanKindLabels.Name(ScanKind.Quick), QuickScanHeadlineCopy.Button());
    }

    [Fact]
    public void Arguments_match_quick_scan_copy()
    {
        Assert.Equal("-Scan -ScanType 1", QuickScanHeadlineCopy.Arguments());
        Assert.Equal(QuickScanCopy.Arguments(), QuickScanHeadlineCopy.Arguments());
        Assert.Equal(ScanTypeArgs.For(ScanKind.Quick), QuickScanHeadlineCopy.Arguments());
    }
}
