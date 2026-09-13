namespace QuietGuard;

public static class TrayTooltip
{
    public const int MaxLength = 63; // Windows NotifyIcon text limit historically 63

    public static string Format(ProtectionVerdict verdict) =>
        Clamp($"QuietGuard · {verdict.Headline}");

    public static string Format(ProtectionLevel level, string headline) =>
        Format(new ProtectionVerdict(level, headline, Array.Empty<string>()));

    public static string Clamp(string text) =>
        string.IsNullOrEmpty(text) ? "QuietGuard" : (text.Length <= MaxLength ? text : text[..MaxLength]);
}
