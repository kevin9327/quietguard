namespace QuietGuard;

public static class SignatureStaleCopy
{
    public static bool IsStale(TimeSpan? age) =>
        SignatureAgeAdvisor.IsStale(age, ProtectionAdvisor.SignatureStaleAfter);

    public static string Headline(TimeSpan? age) =>
        IsStale(age) ? $"정의가 {SignatureAgeAdvisor.FormatAge(age)}입니다" : "정의 나이가 허용 범위입니다";
}
