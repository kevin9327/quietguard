namespace QuietGuard;

public static class DefinitionUpdateAdvisor
{
    public static readonly TimeSpan QuietRefreshAfter = TimeSpan.FromDays(1);

    public static bool ShouldUpdate(bool signaturesOutOfDate, TimeSpan? signatureAge) =>
        signaturesOutOfDate || SignatureAgeAdvisor.IsStale(signatureAge);

    public static bool ShouldNotifyAboutUpdate(bool signaturesOutOfDate, TimeSpan? signatureAge) =>
        ShouldUpdate(signaturesOutOfDate, signatureAge) && signaturesOutOfDate;

    public static string MpCmdArguments() => "-SignatureUpdate";
}
