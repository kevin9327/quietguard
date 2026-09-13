namespace QuietGuard;

public static class ScheduledScanCopy
{
    public static ScanScheduleDecision Decide(
        DateTime utcNow,
        DateTime? lastQuickScanUtc,
        ProtectionLevel level) =>
        ScanScheduler.Decide(utcNow, lastQuickScanUtc, ScanScheduler.DefaultInterval, level);

    public static string Arguments() => QuickScanCopy.Arguments();

    public static bool Quiet(ScanScheduleDecision decision) =>
        decision.ShouldScan && !decision.NotifyUser;
}
