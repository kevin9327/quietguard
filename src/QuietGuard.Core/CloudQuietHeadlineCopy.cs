namespace QuietGuard;

public static class CloudQuietHeadlineCopy
{
    public static bool IsQuiet(bool ioavEnabled, bool behaviorEnabled) =>
        CloudQuietCopy.IsQuiet(ioavEnabled, behaviorEnabled);

    public static string Headline(bool ioavEnabled, bool behaviorEnabled) =>
        CloudQuietCopy.Headline(ioavEnabled, behaviorEnabled);
}
