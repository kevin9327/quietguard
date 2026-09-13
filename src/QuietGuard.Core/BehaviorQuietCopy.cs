namespace QuietGuard;

public static class BehaviorQuietCopy
{
    public static bool IsQuiet(bool enabled) => BehaviorProtectionCopy.IsQuiet(enabled);

    public static string Headline(bool enabled) => BehaviorProtectionCopy.Headline(enabled);

    public static string Headline(DefenderStatus status) => BehaviorProtectionCopy.Headline(status);
}
