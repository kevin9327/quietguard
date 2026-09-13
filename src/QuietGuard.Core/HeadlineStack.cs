namespace QuietGuard;

public static class HeadlineStack
{
    public static IReadOnlyList<string> From(DefenderStatus status) =>
    [
        ProtectionAdvisor.Advise(status).Headline,
        RealtimeProtectionCopy.Headline(status),
        AntivirusEnabledCopy.Headline(status),
        TamperProtectionCopy.Headline(status)
    ];
}
