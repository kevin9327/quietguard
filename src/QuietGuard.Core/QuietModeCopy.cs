namespace QuietGuard;

public static class QuietModeCopy
{
    public static bool Suppress(ProtectionLevel level) => QuietMode.SuppressBalloons(level);

    public static bool Suppress(ProtectionVerdict verdict) => QuietMode.SuppressBalloons(verdict);
}
