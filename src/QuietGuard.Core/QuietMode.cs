namespace QuietGuard;

public static class QuietMode
{
    public static bool SuppressBalloons(ProtectionLevel level) => !BalloonPolicy.Show(level);

    public static bool SuppressBalloons(ProtectionVerdict verdict) => SuppressBalloons(verdict.Level);
}
