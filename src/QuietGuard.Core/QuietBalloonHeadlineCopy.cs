namespace QuietGuard;

public static class QuietBalloonHeadlineCopy
{
    public static bool Suppress(ProtectionLevel level) => QuietBalloonCopy.Suppress(level);

    public static string Headline(ProtectionLevel level) => QuietBalloonCopy.Headline(level);
}
