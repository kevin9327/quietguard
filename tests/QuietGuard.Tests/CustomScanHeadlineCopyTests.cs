using QuietGuard;

namespace QuietGuard.Tests;

public class CustomScanHeadlineCopyTests
{
    [Fact]
    public void Button_is_file_scan_and_equals_custom_scan_copy()
    {
        Assert.Equal("파일 검사", CustomScanHeadlineCopy.Button());
        Assert.Equal(CustomScanCopy.Button(), CustomScanHeadlineCopy.Button());
        Assert.Equal(ScanKindLabels.Name(ScanKind.CustomFile), CustomScanHeadlineCopy.Button());
    }

    [Fact]
    public void Downloads_setup_can_scan_and_arguments_match()
    {
        const string path = @"C:\Users\a\Downloads\setup.exe";
        Assert.True(CustomScanHeadlineCopy.CanScan(path));
        Assert.Equal(CustomScanCopy.CanScan(path), CustomScanHeadlineCopy.CanScan(path));
        Assert.Equal(ScanPathSafety.IsSafeCustomScanTarget(path), CustomScanHeadlineCopy.CanScan(path));
        Assert.Equal(CustomScanCopy.Arguments(path), CustomScanHeadlineCopy.Arguments(path));
        Assert.Equal(ScanTypeArgs.ForFile(path), CustomScanHeadlineCopy.Arguments(path));
    }
}
