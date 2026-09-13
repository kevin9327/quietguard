namespace QuietGuard;

public static class MpCmdCleanHeadlineCopy
{
    public static bool IsClean(int exitCode) => MpCmdCleanCopy.IsClean(exitCode);

    public static string Headline(int exitCode) => MpCmdCleanCopy.Headline(exitCode);

    public static bool Notify(int exitCode) => MpCmdCleanCopy.Notify(exitCode);
}
