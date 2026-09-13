using QuietGuard;

namespace QuietGuard.Tests;

public class CancelScanArgsTests
{
    [Fact]
    public void Cancel_contains_scan_and_cancel_without_scan_type()
    {
        var args = CancelScanArgs.Cancel();
        Assert.Contains("-Scan", args);
        Assert.Contains("-Cancel", args);
        Assert.DoesNotContain("-ScanType", args);
    }
}
