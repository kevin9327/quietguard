namespace QuietGuard;

public static class LastScanStoreCopy
{
    public static DateTime? Parse(string? contents) => LastScanStore.Parse(contents);

    public static string Format(DateTime utc) => LastScanStore.Format(utc);

    public static string FilePath => LastScanStore.FilePath;
}
