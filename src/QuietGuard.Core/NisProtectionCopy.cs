namespace QuietGuard;

public static class NisProtectionCopy
{
    public static string Headline(bool nisEnabled) =>
        nisEnabled ? "네트워크 검사 켜짐" : "네트워크 검사가 꺼져 있습니다";

    public static bool IsQuiet(bool nisEnabled) => nisEnabled;

    public static string Headline(DefenderStatus status) => Headline(status.NisEnabled);

    public static bool IsQuiet(DefenderStatus status) => IsQuiet(status.NisEnabled);
}
