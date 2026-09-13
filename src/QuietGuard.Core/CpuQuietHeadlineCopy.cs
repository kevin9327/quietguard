namespace QuietGuard;

public static class CpuQuietHeadlineCopy
{
    public static bool IsQuiet(float cpuPercent, long workingSetBytes) =>
        CpuQuietCopy.IsQuiet(cpuPercent, workingSetBytes);

    public static string Headline(float cpuPercent, long workingSetBytes) =>
        CpuQuietCopy.Headline(cpuPercent, workingSetBytes);
}
