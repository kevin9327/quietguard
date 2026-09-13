using QuietGuard;

namespace QuietGuard.Tests;

public class CpuQuietHeadlineCopyTests
{
    [Fact]
    public void One_percent_50mb_is_quiet()
    {
        const float cpu = 1f;
        const long ram = 50L * 1024 * 1024;
        Assert.True(CpuQuietHeadlineCopy.IsQuiet(cpu, ram));
        Assert.Equal(CpuQuietCopy.IsQuiet(cpu, ram), CpuQuietHeadlineCopy.IsQuiet(cpu, ram));
        Assert.Equal("리소스 조용함", CpuQuietHeadlineCopy.Headline(cpu, ram));
        Assert.Equal(CpuQuietCopy.Headline(cpu, ram), CpuQuietHeadlineCopy.Headline(cpu, ram));
        Assert.Equal(CpuBudgetCopy.Status(cpu, ram), CpuQuietHeadlineCopy.Headline(cpu, ram));
    }

    [Fact]
    public void Twenty_percent_is_heavy()
    {
        const float cpu = 20f;
        const long ram = 50L * 1024 * 1024;
        Assert.False(CpuQuietHeadlineCopy.IsQuiet(cpu, ram));
        Assert.Equal(CpuQuietCopy.IsQuiet(cpu, ram), CpuQuietHeadlineCopy.IsQuiet(cpu, ram));
        Assert.Contains("무거움", CpuQuietHeadlineCopy.Headline(cpu, ram));
        Assert.Equal(CpuQuietCopy.Headline(cpu, ram), CpuQuietHeadlineCopy.Headline(cpu, ram));
    }
}
