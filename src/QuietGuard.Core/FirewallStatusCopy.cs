namespace QuietGuard;

public static class FirewallStatusCopy
{
    public static string OnOff(bool enabled) => FirewallStatusText.OnOff(enabled);

    public static string Summarize(bool domainEnabled, bool privateEnabled, bool publicEnabled) =>
        FirewallStatusText.Summarize(domainEnabled, privateEnabled, publicEnabled);

    public static bool AllOn(bool domainEnabled, bool privateEnabled, bool publicEnabled) =>
        FirewallStatusText.AllOn(domainEnabled, privateEnabled, publicEnabled);
}
