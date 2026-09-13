namespace QuietGuard;

public static class TrayOpenCopy
{
    public static string Menu() => TrayMenuLabels.Open;

    public static string Exit() => TrayMenuLabels.Exit;

    public static string Tooltip(ProtectionVerdict verdict) => TrayTooltip.Format(verdict);
}
