namespace QuietGuard;

public static class BudgetLineStack
{
    public static IReadOnlyList<string> From(EngineBudget budget) =>
    [
        EngineBudgetMath.FormatLine("Defender", budget.DefenderCpuPercent, budget.DefenderWorkingSetBytes),
        EngineBudgetMath.FormatLine("QuietGuard", budget.AppCpuPercent, budget.AppWorkingSetBytes),
        CpuBudgetCopy.Status(budget.DefenderCpuPercent, budget.DefenderWorkingSetBytes)
    ];
}
