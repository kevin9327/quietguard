namespace QuietGuard;

public static class BalloonPolicy
{
    // Quiet product: balloon only when there is something the user must see.
    public static bool Show(ProtectionLevel level) => level != ProtectionLevel.Protected;

    public static bool Show(ScanScheduleDecision decision) =>
        decision.ShouldScan && decision.NotifyUser;

    public static bool ShowForMpCmd(int exitCode) => !MpCmdExit.IsClean(exitCode);
}
