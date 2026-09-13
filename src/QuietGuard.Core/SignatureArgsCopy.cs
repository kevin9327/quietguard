namespace QuietGuard;

public static class SignatureArgsCopy
{
    public static string Arguments() => DefinitionUpdateAdvisor.MpCmdArguments();

    public static TimeSpan QuietRefreshAfter => DefinitionUpdateAdvisor.QuietRefreshAfter;
}
