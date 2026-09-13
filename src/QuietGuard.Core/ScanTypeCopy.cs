namespace QuietGuard;

public static class ScanTypeCopy
{
    public static string For(ScanKind kind) => ScanTypeArgs.For(kind);

    public static string ForFile(string path) => ScanTypeArgs.ForFile(path);
}
