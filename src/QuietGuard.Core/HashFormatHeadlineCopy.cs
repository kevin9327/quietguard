namespace QuietGuard;

public static class HashFormatHeadlineCopy
{
    public static string Format(string? hex) => HashFormatCopy.Format(hex);

    public static bool LooksValid(string? hex) => HashFormatCopy.LooksValid(hex);
}
