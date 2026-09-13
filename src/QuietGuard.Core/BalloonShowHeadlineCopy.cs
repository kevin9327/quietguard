namespace QuietGuard;

public static class BalloonShowHeadlineCopy
{
    public static bool Show(ProtectionLevel level) => BalloonShowCopy.Show(level);

    public static bool Show(ScanScheduleDecision decision) => BalloonShowCopy.Show(decision);

    public static bool ShowForMpCmd(int exitCode) => BalloonShowCopy.ShowForMpCmd(exitCode);
}
