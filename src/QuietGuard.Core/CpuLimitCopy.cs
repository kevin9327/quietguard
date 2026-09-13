namespace QuietGuard;

public static class CpuLimitCopy
{
    public static float Percent => EngineBudgetMath.DefaultCpuLimitPercent;

    public static long RamBytes => EngineBudgetMath.DefaultRamLimitBytes;

    public static bool Exceeds(float cpuPercent, long workingSetBytes) =>
        EngineBudgetMath.ExceedsQuietBudget(cpuPercent, workingSetBytes);
}
