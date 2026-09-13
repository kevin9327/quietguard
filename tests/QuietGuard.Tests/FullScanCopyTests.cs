using QuietGuard;

namespace QuietGuard.Tests;

public class FullScanCopyTests
{
    [Fact]
    public void Button_matches_ScanKindLabels_full()
    {
        Assert.Equal(ScanKindLabels.Name(ScanKind.Full), FullScanCopy.Button());
        Assert.Equal("전체 검사", FullScanCopy.Button());
    }

    [Fact]
    public void Arguments_match_ScanTypeArgs_For_full()
    {
        Assert.Equal(ScanTypeArgs.For(ScanKind.Full), FullScanCopy.Arguments());
        Assert.Contains("-ScanType 2", FullScanCopy.Arguments());
    }
}
