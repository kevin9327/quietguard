using QuietGuard;

namespace QuietGuard.Tests;

public class CpuLimitCopyTests
{
    [Fact]
    public void Percent_equals_15_and_engine_budget()
    {
        Assert.Equal(15f, CpuLimitCopy.Percent);
        Assert.Equal(EngineBudgetMath.DefaultCpuLimitPercent, CpuLimitCopy.Percent);
        Assert.Equal(EngineBudgetCopy.CpuLimit, CpuLimitCopy.Percent);
    }

    [Fact]
    public void RamBytes_equals_600_mb_and_engine_budget()
    {
        Assert.Equal(600L * 1024 * 1024, CpuLimitCopy.RamBytes);
        Assert.Equal(EngineBudgetCopy.RamLimitBytes, CpuLimitCopy.RamBytes);
    }

    [Fact]
    public void Exceeds_one_percent_and_50mb_is_false()
    {
        const float cpu = 1f;
        const long ram = 50L * 1024 * 1024;

        Assert.False(CpuLimitCopy.Exceeds(cpu, ram));
        Assert.Equal(EngineBudgetMath.ExceedsQuietBudget(cpu, ram), CpuLimitCopy.Exceeds(cpu, ram));
        Assert.Equal(!CpuQuietCopy.IsQuiet(cpu, ram), CpuLimitCopy.Exceeds(cpu, ram));
    }

    [Fact]
    public void Exceeds_twenty_percent_and_50mb_is_true()
    {
        const float cpu = 20f;
        const long ram = 50L * 1024 * 1024;

        Assert.True(CpuLimitCopy.Exceeds(cpu, ram));
        Assert.Equal(EngineBudgetMath.ExceedsQuietBudget(cpu, ram), CpuLimitCopy.Exceeds(cpu, ram));
        Assert.Equal(!CpuQuietCopy.IsQuiet(cpu, ram), CpuLimitCopy.Exceeds(cpu, ram));
    }
}
