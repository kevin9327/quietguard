namespace QuietGuard;

public static class BudgetLineCopy
{
    public static IReadOnlyList<string> From(EngineBudget budget) => BudgetLineStack.From(budget);
}
