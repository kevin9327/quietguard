using QuietGuard;

namespace QuietGuard.Tests;

public class ScanButtonStackTests
{
    [Fact]
    public void Labels_are_the_four_shipped_buttons_in_order()
    {
        IReadOnlyList<string> expected =
        [
            QuickScanCopy.Button(),
            FullScanCopy.Button(),
            CustomScanCopy.Button(),
            ScanCancelCopy.Button()
        ];

        var labels = ScanButtonStack.Labels();

        Assert.Equal(4, labels.Count);
        Assert.Equal(expected, labels);
    }

    [Fact]
    public void Labels_contain_quick_scan_and_cancel()
    {
        var labels = ScanButtonStack.Labels();

        Assert.Contains("빠른 검사", labels);
        Assert.Contains("검사 취소", labels);
    }
}
