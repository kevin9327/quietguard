namespace QuietGuard;

public static class DefinitionFreshCopy
{
    public static bool IsFresh(bool signaturesOutOfDate, TimeSpan? age) =>
        !DefinitionUpdateAdvisor.ShouldUpdate(signaturesOutOfDate, age);

    public static string Headline(bool signaturesOutOfDate, TimeSpan? age) =>
        IsFresh(signaturesOutOfDate, age) ? "정의가 최신입니다" : "정의 갱신이 필요합니다";
}
