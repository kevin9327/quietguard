namespace QuietGuard;

public static class FirewallHeadlineCopy
{
    public static string OnOff(bool enabled) => FirewallStatusCopy.OnOff(enabled);

    public static string Summarize(bool domainEnabled, bool privateEnabled, bool publicEnabled) =>
        FirewallStatusCopy.Summarize(domainEnabled, privateEnabled, publicEnabled);

    public static bool AllOn(bool domainEnabled, bool privateEnabled, bool publicEnabled) =>
        FirewallStatusCopy.AllOn(domainEnabled, privateEnabled, publicEnabled);
}
