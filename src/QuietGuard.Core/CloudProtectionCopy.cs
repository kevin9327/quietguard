namespace QuietGuard;

public static class CloudProtectionCopy
{
    public static string Headline(bool ioavEnabled, bool behaviorEnabled)
    {
        if (ioavEnabled && behaviorEnabled)
            return "클라우드·동작 감시 켜짐";
        if (!ioavEnabled && !behaviorEnabled)
            return "클라우드·동작 감시 꺼짐";
        if (!ioavEnabled)
            return "다운로드 검사가 꺼져 있습니다";
        return "동작 감시가 꺼져 있습니다";
    }

    public static bool IsQuiet(bool ioavEnabled, bool behaviorEnabled) =>
        ioavEnabled && behaviorEnabled;

    public static string Headline(DefenderStatus status) =>
        Headline(status.IoavProtectionEnabled, status.BehaviorMonitorEnabled);
}
