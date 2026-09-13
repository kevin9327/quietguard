namespace QuietGuard;

public static class TrayLevelCopy
{
    public static string Format(ProtectionLevel level, string headline) =>
        TrayTooltip.Format(level, headline);

    public static string Format(ProtectionVerdict verdict) => TrayTooltip.Format(verdict);
}
