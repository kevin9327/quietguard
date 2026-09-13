using System.Globalization;

namespace QuietGuard;

public static class LastScanStore
{
    public static string FilePath =>
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "QuietGuard",
            "last-quick-scan-utc.txt");

    public static DateTime? Parse(string? contents)
    {
        if (string.IsNullOrWhiteSpace(contents))
            return null;
        return DateTime.TryParse(
            contents.Trim(),
            CultureInfo.InvariantCulture,
            DateTimeStyles.RoundtripKind,
            out var parsed)
            ? parsed.ToUniversalTime()
            : null;
    }

    public static string Format(DateTime utc) =>
        utc.ToUniversalTime().ToString("o", CultureInfo.InvariantCulture);

    public static DateTime? Read()
    {
        try
        {
            return File.Exists(FilePath) ? Parse(File.ReadAllText(FilePath)) : null;
        }
        catch (IOException)
        {
            return null;
        }
    }

    public static void Write(DateTime utc)
    {
        var dir = Path.GetDirectoryName(FilePath);
        if (!string.IsNullOrEmpty(dir))
            Directory.CreateDirectory(dir);
        File.WriteAllText(FilePath, Format(utc));
    }
}
