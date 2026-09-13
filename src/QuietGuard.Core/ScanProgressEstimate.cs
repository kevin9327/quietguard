namespace QuietGuard;

public static class ScanProgressEstimate
{
    public static int Percent(TimeSpan elapsed, TimeSpan typicalDuration)
    {
        if (typicalDuration <= TimeSpan.Zero)
            return 0;
        if (elapsed <= TimeSpan.Zero)
            return 0;
        var raw = elapsed.TotalSeconds / typicalDuration.TotalSeconds * 100.0;
        if (raw < 0) return 0;
        if (raw >= 100) return 99;
        return (int)raw;
    }

    public static int Complete() => 100;

    public static TimeSpan TypicalQuickScan => TimeSpan.FromMinutes(3);
}
