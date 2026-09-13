namespace QuietGuard;

public static class StartupHeadlineCopy
{
    public static string LaunchCommand(string exePath) => StartupCopy.LaunchCommand(exePath);

    public static bool IsSafeExe(string exePath) => StartupCopy.IsSafeExe(exePath);

    public static string RunValueName => StartupCopy.RunValueName;
}
