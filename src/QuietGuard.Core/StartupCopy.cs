namespace QuietGuard;

public static class StartupCopy
{
    public static string LaunchCommand(string exePath) =>
        StartupRegistration.FormatLaunchCommand(exePath);

    public static bool IsSafeExe(string exePath) =>
        StartupRegistration.IsSafeExePath(exePath);

    public static string RunValueName => StartupRegistration.RunValueName;
}
