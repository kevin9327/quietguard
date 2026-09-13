namespace QuietGuard;

public static class NisHeadlineCopy
{
    public static bool IsQuiet(bool nisEnabled) => NisQuietCopy.IsQuiet(nisEnabled);

    public static string Headline(bool nisEnabled) => NisQuietCopy.Headline(nisEnabled);

    public static bool IsQuiet(DefenderStatus status) => NisQuietCopy.IsQuiet(status);
}
