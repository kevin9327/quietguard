using QuietGuard;

namespace QuietGuard.Tests;

public class CustomScanCopyTests
{
    [Fact]
    public void Button_matches_ScanKindLabels_custom_file()
    {
        Assert.Equal(ScanKindLabels.Name(ScanKind.CustomFile), CustomScanCopy.Button());
        Assert.Equal("파일 검사", CustomScanCopy.Button());
    }

    [Fact]
    public void Arguments_match_ScanTypeArgs_ForFile()
    {
        var path = @"C:\Users\a\Downloads\setup.exe";
        Assert.Equal(ScanTypeArgs.ForFile(path), CustomScanCopy.Arguments(path));
        Assert.Contains("-ScanType 3", CustomScanCopy.Arguments(path));
        Assert.Contains("\"" + path + "\"", CustomScanCopy.Arguments(path));
    }

    [Fact]
    public void CanScan_uses_ScanPathSafety()
    {
        var downloads = @"C:\Users\a\Downloads\setup.exe";
        var windows = @"C:\Windows\notepad.exe";
        Assert.Equal(ScanPathSafety.IsSafeCustomScanTarget(downloads), CustomScanCopy.CanScan(downloads));
        Assert.Equal(ScanPathSafety.IsSafeCustomScanTarget(windows), CustomScanCopy.CanScan(windows));
        Assert.True(CustomScanCopy.CanScan(downloads));
        Assert.False(CustomScanCopy.CanScan(windows));
    }
}
