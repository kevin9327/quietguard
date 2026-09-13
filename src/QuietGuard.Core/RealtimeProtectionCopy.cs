namespace QuietGuard;

public static class RealtimeProtectionCopy
{
    public static string Headline(bool realtimeEnabled) =>
        realtimeEnabled ? "실시간 보호 켜짐" : "실시간 보호가 꺼져 있습니다";

    public static bool IsQuiet(bool realtimeEnabled) => realtimeEnabled;

    public static string Headline(DefenderStatus status) => Headline(status.RealTimeProtectionEnabled);

    public static bool IsQuiet(DefenderStatus status) => IsQuiet(status.RealTimeProtectionEnabled);
}
