using QuietGuard;

namespace QuietGuard.Tests;

public class EngineBudgetCopyTests
{
    [Fact]
    public void CpuPercent_one_second_on_one_processor_is_100()
    {
        var delta = TimeSpan.FromSeconds(1);
        const double elapsed = 1;
        const int processors = 1;

        Assert.Equal(100f, EngineBudgetCopy.CpuPercent(delta, elapsed, processors));
        Assert.Equal(
            EngineBudgetMath.CpuPercent(delta, elapsed, processors),
            EngineBudgetCopy.CpuPercent(delta, elapsed, processors));
    }

    [Fact]
    public void CpuPercent_one_second_on_two_processors_is_50()
    {
        var delta = TimeSpan.FromSeconds(1);
        const double elapsed = 1;
        const int processors = 2;

        Assert.Equal(50f, EngineBudgetCopy.CpuPercent(delta, elapsed, processors));
        Assert.Equal(
            EngineBudgetMath.CpuPercent(delta, elapsed, processors),
            EngineBudgetCopy.CpuPercent(delta, elapsed, processors));
    }

    [Fact]
    public void CpuPercent_zero_elapsed_is_zero()
    {
        var delta = TimeSpan.FromSeconds(1);

        Assert.Equal(0f, EngineBudgetCopy.CpuPercent(delta, 0, 1));
        Assert.Equal(
            EngineBudgetMath.CpuPercent(delta, 0, 1),
            EngineBudgetCopy.CpuPercent(delta, 0, 1));
    }

    [Fact]
    public void CpuLimit_equals_default_cpu_limit_percent()
    {
        Assert.Equal(15f, EngineBudgetCopy.CpuLimit);
        Assert.Equal(EngineBudgetMath.DefaultCpuLimitPercent, EngineBudgetCopy.CpuLimit);
    }

    [Fact]
    public void RamLimitBytes_equals_600_mb()
    {
        Assert.Equal(600L * 1024 * 1024, EngineBudgetCopy.RamLimitBytes);
        Assert.Equal(EngineBudgetMath.DefaultRamLimitBytes, EngineBudgetCopy.RamLimitBytes);
    }

    [Fact]
    public void FormatLine_defender_matches_math_and_contains_label()
    {
        const string label = "Defender";
        const float cpu = 1f;
        const long ram = 50L * 1024 * 1024;
        var line = EngineBudgetCopy.FormatLine(label, cpu, ram);

        Assert.Equal(EngineBudgetMath.FormatLine(label, cpu, ram), line);
        Assert.Contains("Defender", line);
    }
}
