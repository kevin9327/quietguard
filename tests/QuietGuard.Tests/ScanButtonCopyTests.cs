using QuietGuard;

namespace QuietGuard.Tests;

public class ScanButtonCopyTests
{
    [Fact]
    public void Labels_equal_stack_and_have_four_items()
    {
        IReadOnlyList<string> expected =
        [
            QuickScanCopy.Button(),
            FullScanCopy.Button(),
            CustomScanCopy.Button(),
            ScanCancelCopy.Button()
        ];
        Assert.Equal(expected, ScanButtonCopy.Labels());
        Assert.Equal(ScanButtonStack.Labels(), ScanButtonCopy.Labels());
        Assert.Equal(4, ScanButtonCopy.Labels().Count);
    }

    [Fact]
    public void Labels_contain_quick_scan_and_cancel()
    {
        var labels = ScanButtonCopy.Labels();
        Assert.Contains("빠른 검사", labels);
        Assert.Contains("검사 취소", labels);
    }
}
