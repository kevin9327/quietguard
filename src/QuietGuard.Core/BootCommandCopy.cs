namespace QuietGuard;

public static class BootCommandCopy
{
    public static string LaunchCommand(string exePath) => StartupCopy.LaunchCommand(exePath);

    public static bool IsSafeExe(string exePath) => StartupCopy.IsSafeExe(exePath);
}
