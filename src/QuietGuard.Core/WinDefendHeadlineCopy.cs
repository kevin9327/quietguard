namespace QuietGuard;

public static class WinDefendHeadlineCopy
{
    public static string Service => WinDefendCopy.Service;

    public static string CommandLine => WinDefendCopy.CommandLine;

    public static string EngineProcess => WinDefendCopy.EngineProcess;

    public static bool IsCommandLine(string? fileName) => WinDefendCopy.IsCommandLine(fileName);

    public static bool IsEngineProcess(string? processName) => WinDefendCopy.IsEngineProcess(processName);
}
