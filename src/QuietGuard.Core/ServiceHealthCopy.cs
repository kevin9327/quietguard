namespace QuietGuard;

public static class ServiceHealthCopy
{
    public static string Headline(bool running) =>
        running ? $"{WinDefendNames.Service} 실행 중" : $"{WinDefendNames.Service}이(가) 꺼져 있습니다";

    public static bool IsQuiet(bool running) => running;
}
