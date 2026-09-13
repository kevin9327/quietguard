using QuietGuard;

namespace QuietGuard.Tests;

public class PathSafeHeadlineCopyTests
{
    [Fact]
    public void Downloads_setup_is_safe_and_equals_path_safety_copy()
    {
        const string path = @"C:\Users\a\Downloads\setup.exe";
        Assert.True(PathSafeHeadlineCopy.IsSafe(path));
        Assert.Equal(PathSafetyCopy.IsSafe(path), PathSafeHeadlineCopy.IsSafe(path));
        Assert.Equal(ScanPathSafety.IsSafeCustomScanTarget(path), PathSafeHeadlineCopy.IsSafe(path));
        Assert.Equal("검사 가능한 경로", PathSafeHeadlineCopy.Headline(path));
        Assert.Equal(PathSafetyCopy.Headline(path), PathSafeHeadlineCopy.Headline(path));
    }

    [Fact]
    public void Windows_notepad_is_unsafe()
    {
        const string path = @"C:\Windows\notepad.exe";
        Assert.False(PathSafeHeadlineCopy.IsSafe(path));
        Assert.Equal(PathSafetyCopy.IsSafe(path), PathSafeHeadlineCopy.IsSafe(path));
        Assert.Equal(ScanPathSafety.IsSafeCustomScanTarget(path), PathSafeHeadlineCopy.IsSafe(path));
        Assert.Equal("Windows 경로는 검사하지 않습니다", PathSafeHeadlineCopy.Headline(path));
        Assert.Equal(PathSafetyCopy.Headline(path), PathSafeHeadlineCopy.Headline(path));
    }
}
