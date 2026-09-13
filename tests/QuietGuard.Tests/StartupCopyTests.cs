using QuietGuard;

namespace QuietGuard.Tests;

public class StartupCopyTests
{
    [Fact]
    public void LaunchCommand_quotes_path_and_appends_tray()
    {
        const string path = @"C:\Program Files\QuietGuard\QuietGuard.exe";
        Assert.Equal(@"""C:\Program Files\QuietGuard\QuietGuard.exe"" --tray", StartupCopy.LaunchCommand(path));
        Assert.Equal(StartupRegistration.FormatLaunchCommand(path), StartupCopy.LaunchCommand(path));
    }

    [Fact]
    public void IsSafeExe_rejects_traversal_and_non_exe()
    {
        Assert.False(StartupCopy.IsSafeExe(@"..\evil.exe"));
        Assert.False(StartupCopy.IsSafeExe("notes.txt"));
        Assert.True(StartupCopy.IsSafeExe(@"C:\Program Files\QuietGuard\QuietGuard.exe"));
        Assert.Equal(
            StartupRegistration.IsSafeExePath(@"C:\Program Files\QuietGuard\QuietGuard.exe"),
            StartupCopy.IsSafeExe(@"C:\Program Files\QuietGuard\QuietGuard.exe"));
    }

    [Fact]
    public void RunValueName_equals_QuietGuard()
    {
        Assert.Equal("QuietGuard", StartupCopy.RunValueName);
        Assert.Equal(StartupRegistration.RunValueName, StartupCopy.RunValueName);
    }
}
