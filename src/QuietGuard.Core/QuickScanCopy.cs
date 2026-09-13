namespace QuietGuard;

public static class QuickScanCopy
{
    public static string Button() => ScanKindLabels.Name(ScanKind.Quick);

    public static string Arguments() => ScanTypeArgs.For(ScanKind.Quick);
}
