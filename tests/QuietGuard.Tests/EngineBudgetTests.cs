using QuietGuard;

namespace QuietGuard.Tests;

public class EngineBudgetTests
{
    [Fact]
    public void CpuPercent_one_second_on_one_processor_is_100()
    {
        var cpu = TimeSpan.FromSeconds(1);
        const double elapsed = 1;
        const int processors = 1;
        var expected = (float)(cpu.TotalSeconds / (processors * elapsed) * 100.0);

        Assert.Equal(expected, EngineBudgetMath.CpuPercent(cpu, elapsed, processors));
    }

    [Fact]
    public void CpuPercent_one_second_on_two_processors_is_50()
    {
        var cpu = TimeSpan.FromSeconds(1);
        const double elapsed = 1;
        const int processors = 2;
        var expected = (float)(cpu.TotalSeconds / (processors * elapsed) * 100.0);

        Assert.Equal(expected, EngineBudgetMath.CpuPercent(cpu, elapsed, processors));
    }

    [Fact]
    public void CpuPercent_negative_or_zero_elapsed_is_zero()
    {
        var cpu = TimeSpan.FromSeconds(1);

        Assert.Equal(0f, EngineBudgetMath.CpuPercent(cpu, 0, 1));
        Assert.Equal(0f, EngineBudgetMath.CpuPercent(cpu, -1, 1));
    }

    [Fact]
    public void CpuPercent_clamps_above_100()
    {
        Assert.Equal(100f, EngineBudgetMath.CpuPercent(TimeSpan.FromSeconds(2), 1, 1));
    }

    [Fact]
    public void ExceedsQuietBudget_true_when_cpu_is_20_percent()
    {
        Assert.True(EngineBudgetMath.ExceedsQuietBudget(20f, 50L * 1024 * 1024));
    }

    [Fact]
    public void ExceedsQuietBudget_true_when_ram_is_700_mb()
    {
        Assert.True(EngineBudgetMath.ExceedsQuietBudget(1f, 700L * 1024 * 1024));
    }

    [Fact]
    public void ExceedsQuietBudget_false_when_cpu_1_percent_and_ram_50_mb()
    {
        Assert.False(EngineBudgetMath.ExceedsQuietBudget(1f, 50L * 1024 * 1024));
    }

    [Fact]
    public void FormatLine_contains_label_and_percent_sign()
    {
        var line = EngineBudgetMath.FormatLine("Defender", 1.2f, 120L * 1024 * 1024);

        Assert.Contains("Defender", line);
        Assert.Contains("%", line);
    }
}
