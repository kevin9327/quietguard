namespace QuietGuard;

public static class DefinitionNotifyCopy
{
    public static bool ShouldNotify(bool signaturesOutOfDate, TimeSpan? signatureAge) =>
        DefinitionUpdateAdvisor.ShouldNotifyAboutUpdate(signaturesOutOfDate, signatureAge);

    public static string Arguments() => DefinitionUpdateAdvisor.MpCmdArguments();
}
