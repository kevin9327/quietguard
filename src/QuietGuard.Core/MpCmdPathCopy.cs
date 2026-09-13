namespace QuietGuard;

public static class MpCmdPathCopy
{
    public static string Resolve() => DefenderEngine.ResolveMpCmdRun();

    public static bool IsCommandLine(string? fileName) => WinDefendNames.IsCommandLine(fileName);
}
