namespace QuietGuard;

public static class WatchCooldownCopy
{
    public static TimeSpan Cooldown => DownloadScanAdvisor.Cooldown;

    public static TimeSpan Debounce => DownloadScanAdvisor.Debounce;
}
