namespace QuietGuard;

public static class ProtectionCopy
{
    public static ProtectionVerdict Advise(DefenderStatus status) => ProtectionAdvisor.Advise(status);

    public static TimeSpan SignatureStaleAfter => ProtectionAdvisor.SignatureStaleAfter;
}
