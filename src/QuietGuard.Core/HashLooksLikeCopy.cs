namespace QuietGuard;

public static class HashLooksLikeCopy
{
    public static bool LooksValid(string? hex) => HashText.LooksLikeSha256(hex);

    public static string Headline(string? hex) =>
        LooksValid(hex) ? HashText.FormatSha256(hex) : "유효한 SHA256 아님";
}
