namespace QuietGuard;

public static class CustomScanCopy
{
    public static string Button() => ScanKindLabels.Name(ScanKind.CustomFile);

    public static string Arguments(string path) => ScanTypeArgs.ForFile(path);

    public static bool CanScan(string path) =>
        ScanPathSafety.IsSafeCustomScanTarget(path);
}
