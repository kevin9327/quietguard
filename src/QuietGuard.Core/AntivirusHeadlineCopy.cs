namespace QuietGuard;

public static class AntivirusHeadlineCopy
{
    public static bool IsQuiet(bool antivirusEnabled) => AntivirusQuietCopy.IsQuiet(antivirusEnabled);

    public static string Headline(bool antivirusEnabled) => AntivirusQuietCopy.Headline(antivirusEnabled);
}
