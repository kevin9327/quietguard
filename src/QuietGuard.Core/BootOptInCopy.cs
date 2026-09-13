namespace QuietGuard;

public static class BootOptInCopy
{
    public static string Checkbox() => BootStartCopy.Checkbox();

    public static bool Enabled(bool userOptIn, ProtectionLevel level) =>
        StartupRegistration.ShouldEnableAtBoot(userOptIn, level);
}
