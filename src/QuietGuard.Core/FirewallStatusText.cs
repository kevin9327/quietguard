namespace QuietGuard;

public static class FirewallStatusText
{
    public static string OnOff(bool enabled) => enabled ? "켜짐" : "꺼짐";

    public static string Summarize(bool domainEnabled, bool privateEnabled, bool publicEnabled) =>
        $"방화벽 도메인/개인/공용: {OnOff(domainEnabled)}/{OnOff(privateEnabled)}/{OnOff(publicEnabled)}";

    public static bool AllOn(bool domainEnabled, bool privateEnabled, bool publicEnabled) =>
        domainEnabled && privateEnabled && publicEnabled;
}
