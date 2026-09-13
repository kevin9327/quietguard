using QuietGuard;

namespace QuietGuard.Tests;

public class BudgetLineCopyTests
{
    [Fact]
    public void Quiet_budget_equals_stack_and_ends_quiet()
    {
        var budget = new EngineBudget(1f, 50L * 1024 * 1024, 0.5f, 40L * 1024 * 1024);
        var lines = BudgetLineCopy.From(budget);

        Assert.Equal(BudgetLineStack.From(budget), lines);
        Assert.Equal("리소스 조용함", lines[^1]);
        Assert.Equal(
            EngineBudgetMath.FormatLine("Defender", budget.DefenderCpuPercent, budget.DefenderWorkingSetBytes),
            lines[0]);
    }

    [Fact]
    public void Heavy_twenty_percent_cpu_last_contains_heavy()
    {
        var budget = new EngineBudget(20f, 50L * 1024 * 1024, 0.5f, 40L * 1024 * 1024);
        var lines = BudgetLineCopy.From(budget);

        Assert.Contains("무거움", lines[^1]);
        Assert.Equal(BudgetLineStack.From(budget), lines);
    }
}
