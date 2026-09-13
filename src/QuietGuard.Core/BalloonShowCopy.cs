namespace QuietGuard;

public static class BalloonShowCopy
{
    public static bool Show(ProtectionLevel level) => BalloonPolicy.Show(level);

    public static bool Show(ScanScheduleDecision decision) => BalloonPolicy.Show(decision);

    public static bool ShowForMpCmd(int exitCode) => BalloonPolicy.ShowForMpCmd(exitCode);
}
