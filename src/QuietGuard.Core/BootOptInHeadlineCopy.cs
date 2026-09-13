namespace QuietGuard;

public static class BootOptInHeadlineCopy
{
    public static string Checkbox() => BootOptInCopy.Checkbox();

    public static bool Enabled(bool userOptIn, ProtectionLevel level) =>
        BootOptInCopy.Enabled(userOptIn, level);
}
