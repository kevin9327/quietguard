using QuietGuard;

namespace QuietGuard.Tests;

public class PathSafetyCopyTests
{
    [Fact]
    public void Downloads_setup_exe_is_safe_and_matches_scan_helpers()
    {
        var path = @"C:\Users\a\Downloads\setup.exe";

        Assert.True(PathSafetyCopy.IsSafe(path));
        Assert.Equal(CustomScanCopy.CanScan(path), PathSafetyCopy.IsSafe(path));
        Assert.Equal(ScanPathSafety.IsSafeCustomScanTarget(path), PathSafetyCopy.IsSafe(path));
        Assert.Equal("검사 가능한 경로", PathSafetyCopy.Headline(path));
    }

    [Fact]
    public void Windows_notepad_is_not_safe()
    {
        var path = @"C:\Windows\notepad.exe";

        Assert.False(PathSafetyCopy.IsSafe(path));
        Assert.Equal(CustomScanCopy.CanScan(path), PathSafetyCopy.IsSafe(path));
        Assert.Equal(ScanPathSafety.IsSafeCustomScanTarget(path), PathSafetyCopy.IsSafe(path));
        Assert.Equal("Windows 경로는 검사하지 않습니다", PathSafetyCopy.Headline(path));
        Assert.Contains("Windows 경로", PathSafetyCopy.Headline(path));
    }
}
