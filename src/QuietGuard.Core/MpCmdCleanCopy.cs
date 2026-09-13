namespace QuietGuard;

public static class MpCmdCleanCopy
{
    public static bool IsClean(int exitCode) => MpCmdExit.IsClean(exitCode);

    public static string Headline(int exitCode) => MpCmdExit.Describe(exitCode);

    public static bool Notify(int exitCode) => BalloonPolicy.ShowForMpCmd(exitCode);
}
