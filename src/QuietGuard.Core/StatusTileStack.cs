namespace QuietGuard;

public static class StatusTileStack
{
    public static IReadOnlyList<string> From(DefenderStatus status) =>
    [
        FirewallStatusText.OnOff(status.RealTimeProtectionEnabled),
        FirewallStatusText.OnOff(status.IoavProtectionEnabled),
        FirewallStatusText.OnOff(status.IsTamperProtected),
        SignatureVersionText.Format(status)
    ];
}
