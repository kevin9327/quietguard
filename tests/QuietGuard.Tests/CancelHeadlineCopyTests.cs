using QuietGuard;

namespace QuietGuard.Tests;

public class CancelHeadlineCopyTests
{
    [Fact]
    public void Button_matches_scan_cancel_copy()
    {
        Assert.Equal(ScanCancelCopy.Button(), CancelHeadlineCopy.Button());
        Assert.Equal("검사 취소", CancelHeadlineCopy.Button());
    }

    [Fact]
    public void Arguments_match_scan_cancel_copy_and_cancel_args()
    {
        Assert.Equal(ScanCancelCopy.Arguments(), CancelHeadlineCopy.Arguments());
        Assert.Equal(CancelScanArgs.Cancel(), CancelHeadlineCopy.Arguments());
        Assert.Contains("-Cancel", CancelHeadlineCopy.Arguments());
    }
}
