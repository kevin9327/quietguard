namespace QuietGuard;

public static class HashText
{
    public static string FormatSha256(string? hex)
    {
        if (string.IsNullOrWhiteSpace(hex)) return "해시 없음";
        var trimmed = hex.Trim().Replace(" ", "", StringComparison.Ordinal);
        if (trimmed.Length != 64) return "해시 없음";
        return trimmed.ToLowerInvariant();
    }

    public static bool LooksLikeSha256(string? hex)
    {
        var formatted = FormatSha256(hex);
        return formatted != "해시 없음";
    }
}
