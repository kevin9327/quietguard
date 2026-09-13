using QuietGuard;

namespace QuietGuard.Tests;

public class ScanCancelCopyTests
{
    [Fact]
    public void Button_is_scan_cancel()
    {
        Assert.Equal("검사 취소", ScanCancelCopy.Button());
    }

    [Fact]
    public void Arguments_equals_CancelScanArgs_Cancel_and_contains_cancel()
    {
        Assert.Equal(CancelScanArgs.Cancel(), ScanCancelCopy.Arguments());
        Assert.Contains("-Cancel", ScanCancelCopy.Arguments());
    }
}
