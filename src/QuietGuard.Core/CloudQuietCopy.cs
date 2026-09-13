namespace QuietGuard;

public static class CloudQuietCopy
{
    public static bool IsQuiet(bool ioavEnabled, bool behaviorEnabled) =>
        CloudProtectionCopy.IsQuiet(ioavEnabled, behaviorEnabled);

    public static string Headline(bool ioavEnabled, bool behaviorEnabled) =>
        CloudProtectionCopy.Headline(ioavEnabled, behaviorEnabled);

    public static string Headline(DefenderStatus status) => CloudProtectionCopy.Headline(status);
}
