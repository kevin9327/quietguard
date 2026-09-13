namespace QuietGuard;

public static class CustomScanHeadlineCopy
{
    public static string Button() => CustomScanCopy.Button();

    public static string Arguments(string path) => CustomScanCopy.Arguments(path);

    public static bool CanScan(string path) => CustomScanCopy.CanScan(path);
}
