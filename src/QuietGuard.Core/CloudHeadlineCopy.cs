namespace QuietGuard;

public static class CloudHeadlineCopy
{
    public static IReadOnlyList<string> From(DefenderStatus status) => CloudHeadlineStack.From(status);
}
