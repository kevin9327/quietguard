namespace QuietGuard;

public static class SignatureAgeCopy
{
    public static TimeSpan DefaultLimit => SignatureAgeAdvisor.DefaultLimit;

    public static string FormatAge(TimeSpan? age) => SignatureAgeAdvisor.FormatAge(age);
}
