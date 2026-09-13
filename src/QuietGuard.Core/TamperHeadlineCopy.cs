namespace QuietGuard;

public static class TamperHeadlineCopy
{
    public static bool IsQuiet(bool tamperEnabled) => TamperQuietCopy.IsQuiet(tamperEnabled);

    public static string Headline(bool tamperEnabled) => TamperQuietCopy.Headline(tamperEnabled);
}
