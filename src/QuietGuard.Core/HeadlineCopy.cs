namespace QuietGuard;

public static class HeadlineCopy
{
    public static IReadOnlyList<string> From(DefenderStatus status) => HeadlineStack.From(status);
}
