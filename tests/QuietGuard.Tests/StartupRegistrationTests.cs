using QuietGuard;

namespace QuietGuard.Tests;

public class StartupRegistrationTests
{
    [Fact]
    public void FormatLaunchCommand_quotes_path_and_appends_tray()
    {
        var command = StartupRegistration.FormatLaunchCommand(
            @"C:\Program Files\QuietGuard\QuietGuard.exe");

        Assert.Equal(@"""C:\Program Files\QuietGuard\QuietGuard.exe"" --tray", command);
    }

    [Fact]
    public void FormatLaunchCommand_empty_path_throws()
    {
        Assert.Throws<ArgumentException>(() => StartupRegistration.FormatLaunchCommand(""));
        Assert.Throws<ArgumentException>(() => StartupRegistration.FormatLaunchCommand("   "));
    }

    [Theory]
    [InlineData(true, ProtectionLevel.Protected, true)]
    [InlineData(true, ProtectionLevel.Attention, true)]
    [InlineData(true, ProtectionLevel.Unprotected, true)]
    [InlineData(false, ProtectionLevel.Protected, false)]
    [InlineData(false, ProtectionLevel.Unprotected, false)]
    public void ShouldEnableAtBoot_follows_user_opt_in(
        bool userOptIn,
        ProtectionLevel currentLevel,
        bool expected)
    {
        Assert.Equal(expected, StartupRegistration.ShouldEnableAtBoot(userOptIn, currentLevel));
    }

    [Fact]
    public void IsSafeExePath_rejects_parent_traversal_and_non_exe()
    {
        Assert.False(StartupRegistration.IsSafeExePath(@"..\evil.exe"));
        Assert.False(StartupRegistration.IsSafeExePath("notes.txt"));
        Assert.False(StartupRegistration.IsSafeExePath(""));
        Assert.True(StartupRegistration.IsSafeExePath(@"C:\Program Files\QuietGuard\QuietGuard.exe"));
        Assert.True(StartupRegistration.IsSafeExePath(@"C:\Apps\QuietGuard.EXE"));
    }
}
