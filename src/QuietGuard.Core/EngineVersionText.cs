namespace QuietGuard;

public static class EngineVersionText
{
    public static string Format(string? version) =>
        string.IsNullOrWhiteSpace(version) ? "엔진 버전 없음" : version.Trim();

    public static string Format(DefenderStatus status) => Format(status.EngineVersion);
}
