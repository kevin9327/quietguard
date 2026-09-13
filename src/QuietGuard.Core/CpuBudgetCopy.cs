namespace QuietGuard;

public static class CpuBudgetCopy
{
    public static string Status(float cpuPercent, long workingSetBytes) =>
        EngineBudgetMath.ExceedsQuietBudget(cpuPercent, workingSetBytes) ? "리소스 무거움" : "리소스 조용함";
}
