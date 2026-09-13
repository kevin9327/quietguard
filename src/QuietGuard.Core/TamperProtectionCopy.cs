namespace QuietGuard;

public static class TamperProtectionCopy
{
    public static string Headline(bool tamperEnabled) =>
        tamperEnabled ? "변조 방지 켜짐" : "변조 방지가 꺼져 있습니다";

    public static bool IsQuiet(bool tamperEnabled) => tamperEnabled;

    public static string Headline(DefenderStatus status) => Headline(status.IsTamperProtected);

    public static bool IsQuiet(DefenderStatus status) => IsQuiet(status.IsTamperProtected);
}
