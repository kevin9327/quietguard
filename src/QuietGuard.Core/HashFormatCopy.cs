namespace QuietGuard;

public static class HashFormatCopy
{
    public static string Format(string? hex) => HashText.FormatSha256(hex);

    public static bool LooksValid(string? hex) => HashText.LooksLikeSha256(hex);
}
