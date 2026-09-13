using QuietGuard;

namespace QuietGuard.Tests;

public class ScanPathSafetyTests
{
    [Fact]
    public void IsSafeCustomScanTarget_empty_is_false()
    {
        Assert.False(ScanPathSafety.IsSafeCustomScanTarget(""));
    }

    [Fact]
    public void IsSafeCustomScanTarget_relative_foo_exe_is_false()
    {
        Assert.False(ScanPathSafety.IsSafeCustomScanTarget("foo.exe"));
    }

    [Fact]
    public void IsSafeCustomScanTarget_windows_notepad_is_false()
    {
        Assert.False(ScanPathSafety.IsSafeCustomScanTarget(@"C:\Windows\notepad.exe"));
    }

    [Fact]
    public void IsSafeCustomScanTarget_system_kernel32_is_false()
    {
        var path = Environment.SystemDirectory + @"\kernel32.dll";
        Assert.False(ScanPathSafety.IsSafeCustomScanTarget(path));
    }

    [Fact]
    public void IsSafeCustomScanTarget_user_downloads_file_is_true()
    {
        Assert.True(ScanPathSafety.IsSafeCustomScanTarget(@"C:\Users\a\Downloads\setup.exe"));
    }
}
