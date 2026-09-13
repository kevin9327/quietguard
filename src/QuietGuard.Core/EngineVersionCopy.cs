namespace QuietGuard;

public static class EngineVersionCopy
{
    public static string Headline(string? version) => EngineVersionText.Format(version);

    public static string Headline(DefenderStatus status) => EngineVersionText.Format(status);
}
