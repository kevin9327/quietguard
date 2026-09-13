using QuietGuard;

namespace QuietGuard.Tests;

public class FullScanHeadlineCopyTests
{
    [Fact]
    public void Button_is_full_scan_and_equals_copy()
    {
        Assert.Equal("전체 검사", FullScanHeadlineCopy.Button());
        Assert.Equal(FullScanCopy.Button(), FullScanHeadlineCopy.Button());
        Assert.Equal(ScanKindLabels.Name(ScanKind.Full), FullScanHeadlineCopy.Button());
    }

    [Fact]
    public void Arguments_match_full_scan_copy()
    {
        Assert.Equal("-Scan -ScanType 2", FullScanHeadlineCopy.Arguments());
        Assert.Equal(FullScanCopy.Arguments(), FullScanHeadlineCopy.Arguments());
        Assert.Equal(ScanTypeArgs.For(ScanKind.Full), FullScanHeadlineCopy.Arguments());
    }
}
