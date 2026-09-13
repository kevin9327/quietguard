namespace QuietGuard;

public static class StaleAfterCopy
{
    public static TimeSpan Days => ProtectionAdvisor.SignatureStaleAfter;

    public static TimeSpan AdvisorLimit => SignatureAgeAdvisor.DefaultLimit;
}
