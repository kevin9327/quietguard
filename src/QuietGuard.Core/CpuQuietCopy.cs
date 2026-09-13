namespace QuietGuard;

public static class CpuQuietCopy
{
    public static bool IsQuiet(float cpuPercent, long workingSetBytes) =>
        !EngineBudgetMath.ExceedsQuietBudget(cpuPercent, workingSetBytes);

    public static string Headline(float cpuPercent, long workingSetBytes) =>
        CpuBudgetCopy.Status(cpuPercent, workingSetBytes);
}
