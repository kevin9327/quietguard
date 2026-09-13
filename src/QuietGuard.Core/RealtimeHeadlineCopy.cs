namespace QuietGuard;

public static class RealtimeHeadlineCopy
{
    public static bool IsQuiet(bool realtimeEnabled) => RealtimeQuietCopy.IsQuiet(realtimeEnabled);

    public static string Headline(bool realtimeEnabled) => RealtimeQuietCopy.Headline(realtimeEnabled);

    public static bool IsQuiet(DefenderStatus status) => RealtimeQuietCopy.IsQuiet(status);
}
