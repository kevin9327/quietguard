namespace QuietGuard;

public static class SignatureVersionText
{
    public static string Format(string? version) =>
        string.IsNullOrWhiteSpace(version) ? "정의 버전 없음" : version.Trim();

    public static string Format(DefenderStatus status) => Format(status.SignatureVersion);
}
