namespace QuietGuard;

public static class SignatureStaleHeadlineCopy
{
    public static bool IsStale(TimeSpan? age) => SignatureStaleCopy.IsStale(age);

    public static string Headline(TimeSpan? age) => SignatureStaleCopy.Headline(age);
}
