using QuietGuard;

namespace QuietGuard.Tests;

public class TrayMenuLabelsTests
{
    [Fact]
    public void Open_is_korean_and_not_empty()
    {
        Assert.Equal("열기", TrayMenuLabels.Open);
        Assert.False(string.IsNullOrEmpty(TrayMenuLabels.Open));
    }

    [Fact]
    public void Exit_is_korean_and_not_empty()
    {
        Assert.Equal("종료", TrayMenuLabels.Exit);
        Assert.False(string.IsNullOrEmpty(TrayMenuLabels.Exit));
    }

    [Fact]
    public void QuickScan_is_korean_and_not_empty()
    {
        Assert.Equal("빠른 검사", TrayMenuLabels.QuickScan);
        Assert.False(string.IsNullOrEmpty(TrayMenuLabels.QuickScan));
    }

    [Fact]
    public void UpdateDefinitions_is_korean_and_not_empty()
    {
        Assert.Equal("정의 업데이트", TrayMenuLabels.UpdateDefinitions);
        Assert.False(string.IsNullOrEmpty(TrayMenuLabels.UpdateDefinitions));
    }
}
