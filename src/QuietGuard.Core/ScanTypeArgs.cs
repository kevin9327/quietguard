namespace QuietGuard;

public enum ScanKind
{
    Quick = 1,
    Full = 2,
    CustomFile = 3
}

public static class ScanTypeArgs
{
    public static string For(ScanKind kind)
    {
        if (kind is ScanKind.Quick or ScanKind.Full)
            return $"-Scan -ScanType {(int)kind}";

        throw new ArgumentException("CustomFile requires ForFile.", nameof(kind));
    }

    public static string ForFile(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("path");

        return $"-Scan -ScanType 3 -File \"{path}\"";
    }
}
