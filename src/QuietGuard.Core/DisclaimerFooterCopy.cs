namespace QuietGuard;

public static class DisclaimerFooterCopy
{
    public static string Text() => ProductDisclaimer.Footer();

    public static bool MentionsDefender() =>
        Text().Contains(ProductDisclaimer.Engine, StringComparison.Ordinal);

    public static bool RejectsV3() =>
        Text().Contains(ProductDisclaimer.NotAhnLab, StringComparison.Ordinal);
}
