namespace QuietGuard;

public static class ScanElapsedCopy
{
    public static string Headline(TimeSpan elapsed) => ScanElapsedText.Format(elapsed);

    public static string WithPercent(TimeSpan elapsed, TimeSpan typical) =>
        ScanElapsedText.WithPercent(elapsed, typical);
}
