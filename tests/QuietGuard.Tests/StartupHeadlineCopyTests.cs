using QuietGuard;

namespace QuietGuard.Tests;

public class StartupHeadlineCopyTests
{
    [Fact]
    public void LaunchCommand_equals_startup_copy()
    {
        const string path = @"C:\Program Files\QuietGuard\QuietGuard.exe";
        Assert.Equal(StartupCopy.LaunchCommand(path), StartupHeadlineCopy.LaunchCommand(path));
        Assert.Equal(StartupRegistration.FormatLaunchCommand(path), StartupHeadlineCopy.LaunchCommand(path));
        Assert.Equal(@"""C:\Program Files\QuietGuard\QuietGuard.exe"" --tray", StartupHeadlineCopy.LaunchCommand(path));
    }

    [Fact]
    public void RunValueName_is_QuietGuard()
    {
        Assert.Equal("QuietGuard", StartupHeadlineCopy.RunValueName);
        Assert.Equal(StartupCopy.RunValueName, StartupHeadlineCopy.RunValueName);
        Assert.Equal(StartupRegistration.RunValueName, StartupHeadlineCopy.RunValueName);
        Assert.True(StartupHeadlineCopy.IsSafeExe(@"C:\Program Files\QuietGuard\QuietGuard.exe"));
        Assert.Equal(
            StartupCopy.IsSafeExe(@"C:\Program Files\QuietGuard\QuietGuard.exe"),
            StartupHeadlineCopy.IsSafeExe(@"C:\Program Files\QuietGuard\QuietGuard.exe"));
    }
}
