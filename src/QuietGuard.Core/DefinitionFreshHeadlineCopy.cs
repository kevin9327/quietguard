namespace QuietGuard;

public static class DefinitionFreshHeadlineCopy
{
    public static bool IsFresh(bool signaturesOutOfDate, TimeSpan? age) =>
        DefinitionFreshCopy.IsFresh(signaturesOutOfDate, age);

    public static string Headline(bool signaturesOutOfDate, TimeSpan? age) =>
        DefinitionFreshCopy.Headline(signaturesOutOfDate, age);
}
