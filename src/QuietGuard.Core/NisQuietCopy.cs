namespace QuietGuard;

public static class NisQuietCopy
{
    public static bool IsQuiet(bool nisEnabled) => NisProtectionCopy.IsQuiet(nisEnabled);

    public static string Headline(bool nisEnabled) => NisProtectionCopy.Headline(nisEnabled);

    public static bool IsQuiet(DefenderStatus status) => NisProtectionCopy.IsQuiet(status);
}
