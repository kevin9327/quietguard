namespace QuietGuard;

public static class EngineProcessHeadlineCopy
{
    public static string Headline(bool running) => EngineProcessCopy.Headline(running);

    public static bool Matches(string? processName) => EngineProcessCopy.Matches(processName);
}
