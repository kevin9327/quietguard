namespace QuietGuard;

public static class StartupRegistration
{
    public const string RunValueName = "QuietGuard";
    public const string RunKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";

    public static string FormatLaunchCommand(string exePath)
    {
        if (string.IsNullOrWhiteSpace(exePath))
            throw new ArgumentException("Executable path is required.", nameof(exePath));

        return $"\"{exePath}\" --tray";
    }

    // Boot-start is optional: never force from protection state. Unprotected still
    // allows a login repair pass when the user opted in.
    public static bool ShouldEnableAtBoot(bool userOptIn, ProtectionLevel currentLevel)
    {
        _ = currentLevel;
        return userOptIn;
    }

    public static bool IsSafeExePath(string exePath)
    {
        if (string.IsNullOrWhiteSpace(exePath))
            return false;
        if (exePath.Contains("..", StringComparison.Ordinal))
            return false;
        return exePath.EndsWith(".exe", StringComparison.OrdinalIgnoreCase);
    }
}
