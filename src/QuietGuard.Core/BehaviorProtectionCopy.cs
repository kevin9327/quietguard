namespace QuietGuard;

public static class BehaviorProtectionCopy
{
    public static string Headline(bool enabled) =>
        enabled ? "동작 감시 켜짐" : "동작 감시가 꺼져 있습니다";

    public static bool IsQuiet(bool enabled) => enabled;

    public static string Headline(DefenderStatus status) => Headline(status.BehaviorMonitorEnabled);
}
