namespace QuietGuard;

public static class WinDefendNames
{
    public const string Service = "WinDefend";
    public const string EngineProcess = "MsMpEng";
    public const string CommandLine = "MpCmdRun.exe";

    public static bool IsEngineProcess(string? processName) =>
        string.Equals(processName, EngineProcess, StringComparison.OrdinalIgnoreCase);

    public static bool IsCommandLine(string? fileName) =>
        string.Equals(Path.GetFileName(fileName), CommandLine, StringComparison.OrdinalIgnoreCase);
}
