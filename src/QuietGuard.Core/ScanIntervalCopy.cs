namespace QuietGuard;

public static class ScanIntervalCopy
{
    public static TimeSpan Default => ScanScheduler.DefaultInterval;

    public static bool IsDefault(TimeSpan interval) => interval == ScanScheduler.DefaultInterval;
}
