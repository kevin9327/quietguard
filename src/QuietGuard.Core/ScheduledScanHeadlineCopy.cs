namespace QuietGuard;

public static class ScheduledScanHeadlineCopy
{
    public static ScanScheduleDecision Decide(
        DateTime utcNow,
        DateTime? lastQuickScanUtc,
        ProtectionLevel level) =>
        ScheduledScanCopy.Decide(utcNow, lastQuickScanUtc, level);

    public static string Arguments() => ScheduledScanCopy.Arguments();

    public static bool Quiet(ScanScheduleDecision decision) =>
        ScheduledScanCopy.Quiet(decision);
}
