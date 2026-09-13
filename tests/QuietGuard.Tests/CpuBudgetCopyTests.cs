using QuietGuard;

namespace QuietGuard.Tests;

public class CpuBudgetCopyTests
{
    private const long QuietRamBytes = 50L * 1024 * 1024;

    [Fact]
    public void One_percent_and_50mb_is_quiet()
    {
        const float cpu = 1f;

        Assert.Equal("리소스 조용함", CpuBudgetCopy.Status(cpu, QuietRamBytes));
        Assert.False(EngineBudgetMath.ExceedsQuietBudget(cpu, QuietRamBytes));
        Assert.Contains("%", EngineBudgetMath.FormatLine("QuietGuard", cpu, QuietRamBytes));
    }

    [Fact]
    public void Twenty_percent_default_is_heavy()
    {
        const float cpu = 20f;

        Assert.Contains("무거움", CpuBudgetCopy.Status(cpu, QuietRamBytes));
        Assert.True(EngineBudgetMath.ExceedsQuietBudget(cpu, QuietRamBytes));
        Assert.Contains("%", EngineBudgetMath.FormatLine("QuietGuard", cpu, QuietRamBytes));
    }
}
