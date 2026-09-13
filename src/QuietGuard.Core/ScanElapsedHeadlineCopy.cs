namespace QuietGuard;

public static class ScanElapsedHeadlineCopy
{
    public static string Headline(TimeSpan elapsed) => ScanElapsedCopy.Headline(elapsed);

    public static string WithPercent(TimeSpan elapsed, TimeSpan typical) =>
        ScanElapsedCopy.WithPercent(elapsed, typical);
}
