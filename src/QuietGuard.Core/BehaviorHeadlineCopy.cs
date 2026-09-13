namespace QuietGuard;

public static class BehaviorHeadlineCopy
{
    public static bool IsQuiet(bool enabled) => BehaviorQuietCopy.IsQuiet(enabled);

    public static string Headline(bool enabled) => BehaviorQuietCopy.Headline(enabled);
}
