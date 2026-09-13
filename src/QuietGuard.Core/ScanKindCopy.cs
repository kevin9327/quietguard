namespace QuietGuard;

public static class ScanKindCopy
{
    public static string Name(ScanKind kind) => ScanKindLabels.Name(kind);

    public static string Quick() => ScanKindLabels.Name(ScanKind.Quick);

    public static string Full() => ScanKindLabels.Name(ScanKind.Full);

    public static string CustomFile() => ScanKindLabels.Name(ScanKind.CustomFile);
}
