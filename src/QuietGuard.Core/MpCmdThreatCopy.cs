namespace QuietGuard;

public static class MpCmdThreatCopy
{
    public static bool IsThreatDetected(int code) => MpCmdExit.IsThreatDetected(code);

    public static string Headline(int code) => MpCmdExit.Describe(code);
}
