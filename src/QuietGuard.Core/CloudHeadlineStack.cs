namespace QuietGuard;

public static class CloudHeadlineStack
{
    public static IReadOnlyList<string> From(DefenderStatus status) =>
    [
        CloudProtectionCopy.Headline(status),
        IoavProtectionCopy.Headline(status),
        BehaviorProtectionCopy.Headline(status),
        NisProtectionCopy.Headline(status)
    ];
}
