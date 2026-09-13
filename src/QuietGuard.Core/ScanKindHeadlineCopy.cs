namespace QuietGuard;

public static class ScanKindHeadlineCopy
{
    public static string Name(ScanKind kind) => ScanKindCopy.Name(kind);

    public static string Quick() => ScanKindCopy.Quick();

    public static string Full() => ScanKindCopy.Full();

    public static string CustomFile() => ScanKindCopy.CustomFile();
}
