namespace QuietGuard;

public static class FullScanCopy
{
    public static string Button() => ScanKindLabels.Name(ScanKind.Full);

    public static string Arguments() => ScanTypeArgs.For(ScanKind.Full);
}
