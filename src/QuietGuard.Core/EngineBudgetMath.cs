namespace QuietGuard;

public static class EngineBudgetMath
{
    public const float DefaultCpuLimitPercent = 15f;
    public const long DefaultRamLimitBytes = 600L * 1024 * 1024;

    public static float CpuPercent(TimeSpan delta, double elapsedSeconds, int processorCount)
    {
        if (elapsedSeconds <= 0 || processorCount <= 0)
            return 0;

        var percent = delta.TotalSeconds / (processorCount * elapsedSeconds) * 100.0;
        if (percent < 0) return 0;
        if (percent > 100) return 100;
        return (float)percent;
    }

    public static bool ExceedsQuietBudget(
        float cpuPercent,
        long workingSetBytes,
        float cpuLimit = DefaultCpuLimitPercent,
        long ramLimitBytes = DefaultRamLimitBytes) =>
        cpuPercent > cpuLimit || workingSetBytes > ramLimitBytes;

    public static string FormatLine(string label, float cpuPercent, long workingSetBytes)
    {
        var mb = workingSetBytes / (1024.0 * 1024.0);
        return $"{label} {cpuPercent:0.0}% · {mb:0} MB";
    }
}
