namespace QuietGuard;

public static class RealtimeQuietCopy
{
    public static bool IsQuiet(bool realtimeEnabled) => RealtimeProtectionCopy.IsQuiet(realtimeEnabled);

    public static string Headline(bool realtimeEnabled) => RealtimeProtectionCopy.Headline(realtimeEnabled);

    public static bool IsQuiet(DefenderStatus status) => RealtimeProtectionCopy.IsQuiet(status);
}
