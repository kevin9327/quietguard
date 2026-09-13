using QuietGuard;

namespace QuietGuard.Tests;

public class CpuQuietCopyTests
{
    [Fact]
    public void Light_load_is_quiet()
    {
        const float cpu = 1f;
        const long ram = 50L * 1024 * 1024;
        Assert.Equal(!EngineBudgetMath.ExceedsQuietBudget(cpu, ram), CpuQuietCopy.IsQuiet(cpu, ram));
        Assert.True(CpuQuietCopy.IsQuiet(cpu, ram));
        Assert.Equal(CpuBudgetCopy.Status(cpu, ram), CpuQuietCopy.Headline(cpu, ram));
        Assert.Equal("리소스 조용함", CpuQuietCopy.Headline(cpu, ram));
    }

    [Fact]
    public void Heavy_cpu_is_not_quiet()
    {
        const float cpu = 20f;
        const long ram = 50L * 1024 * 1024;
        Assert.Equal(EngineBudgetMath.ExceedsQuietBudget(cpu, ram), !CpuQuietCopy.IsQuiet(cpu, ram));
        Assert.False(CpuQuietCopy.IsQuiet(cpu, ram));
        Assert.Equal(CpuBudgetCopy.Status(cpu, ram), CpuQuietCopy.Headline(cpu, ram));
        Assert.Contains("무거움", CpuQuietCopy.Headline(cpu, ram));
    }
}
