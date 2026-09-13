namespace QuietGuard;

public static class EngineBudgetCopy
{
    public static float CpuLimit => EngineBudgetMath.DefaultCpuLimitPercent;

    public static long RamLimitBytes => EngineBudgetMath.DefaultRamLimitBytes;

    public static float CpuPercent(TimeSpan delta, double elapsedSeconds, int processorCount) =>
        EngineBudgetMath.CpuPercent(delta, elapsedSeconds, processorCount);

    public static string FormatLine(string label, float cpuPercent, long workingSetBytes) =>
        EngineBudgetMath.FormatLine(label, cpuPercent, workingSetBytes);
}
