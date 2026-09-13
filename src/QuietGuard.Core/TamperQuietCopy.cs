namespace QuietGuard;

public static class TamperQuietCopy
{
    public static bool IsQuiet(bool tamperEnabled) => TamperProtectionCopy.IsQuiet(tamperEnabled);

    public static string Headline(bool tamperEnabled) => TamperProtectionCopy.Headline(tamperEnabled);

    public static bool IsQuiet(DefenderStatus status) => TamperProtectionCopy.IsQuiet(status);
}
