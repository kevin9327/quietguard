using QuietGuard;

namespace QuietGuard.Tests;

public class BootCommandCopyTests
{
    [Fact]
    public void LaunchCommand_equals_startup_copy()
    {
        const string path = @"C:\Program Files\QuietGuard\QuietGuard.exe";
        Assert.Equal(StartupCopy.LaunchCommand(path), BootCommandCopy.LaunchCommand(path));
        Assert.Equal(StartupRegistration.FormatLaunchCommand(path), BootCommandCopy.LaunchCommand(path));
        Assert.Equal(@"""C:\Program Files\QuietGuard\QuietGuard.exe"" --tray", BootCommandCopy.LaunchCommand(path));
    }

    [Fact]
    public void IsSafeExe_equals_startup_copy()
    {
        Assert.True(BootCommandCopy.IsSafeExe(@"C:\Program Files\QuietGuard\QuietGuard.exe"));
        Assert.False(BootCommandCopy.IsSafeExe(@"..\evil.exe"));
        Assert.Equal(
            StartupCopy.IsSafeExe(@"C:\Program Files\QuietGuard\QuietGuard.exe"),
            BootCommandCopy.IsSafeExe(@"C:\Program Files\QuietGuard\QuietGuard.exe"));
        Assert.Equal(
            StartupRegistration.IsSafeExePath(@"..\evil.exe"),
            BootCommandCopy.IsSafeExe(@"..\evil.exe"));
    }
}
