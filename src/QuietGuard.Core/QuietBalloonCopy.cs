namespace QuietGuard;

public static class QuietBalloonCopy
{
    public static bool Suppress(ProtectionLevel level) => QuietMode.SuppressBalloons(level);

    public static string Headline(ProtectionLevel level) =>
        Suppress(level) ? "알림 없음" : "알림 표시";
}
