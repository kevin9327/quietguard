using QuietGuard;

namespace QuietGuard.Tests;

public class CancelArgsCopyTests
{
    [Fact]
    public void Cancel_equals_scan_cancel_args_and_copy()
    {
        Assert.Equal("-Scan -Cancel", CancelArgsCopy.Cancel());
        Assert.Equal(CancelScanArgs.Cancel(), CancelArgsCopy.Cancel());
        Assert.Equal(ScanCancelCopy.Arguments(), CancelArgsCopy.Cancel());
    }

    [Fact]
    public void Button_equals_scan_cancel_copy()
    {
        Assert.Equal("검사 취소", CancelArgsCopy.Button());
        Assert.Equal(ScanCancelCopy.Button(), CancelArgsCopy.Button());
    }
}
