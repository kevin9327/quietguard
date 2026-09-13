namespace QuietGuard;

public static class EngineProcessCopy
{
    public static string Headline(bool running) =>
        running
            ? $"{WinDefendNames.EngineProcess} 실행 중"
            : $"{WinDefendNames.EngineProcess}이(가) 없습니다";

    public static bool Matches(string? processName) => WinDefendNames.IsEngineProcess(processName);
}
