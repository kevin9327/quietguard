namespace QuietGuard;

public static class WinDefendCopy
{
    public static string Service => WinDefendNames.Service;

    public static string CommandLine => WinDefendNames.CommandLine;

    public static string EngineProcess => WinDefendNames.EngineProcess;

    public static bool IsCommandLine(string? fileName) => WinDefendNames.IsCommandLine(fileName);

    public static bool IsEngineProcess(string? processName) => WinDefendNames.IsEngineProcess(processName);
}
