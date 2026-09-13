namespace QuietGuard;

public static class AntivirusQuietCopy
{
    public static bool IsQuiet(bool antivirusEnabled) => AntivirusEnabledCopy.IsQuiet(antivirusEnabled);

    public static string Headline(bool antivirusEnabled) => AntivirusEnabledCopy.Headline(antivirusEnabled);

    public static bool IsQuiet(DefenderStatus status) => AntivirusEnabledCopy.IsQuiet(status);
}
