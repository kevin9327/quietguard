namespace QuietGuard;

public static class DownloadWatchFilter
{
    private static readonly HashSet<string> ScanExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".exe", ".dll", ".scr", ".com", ".msi", ".msix", ".appx",
        ".js", ".jse", ".vbs", ".vbe", ".wsf", ".wsh",
        ".cmd", ".bat", ".ps1", ".hta", ".jar", ".pif"
    };

    public static bool ShouldScan(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return false;

        var name = Path.GetFileName(path);
        if (name.StartsWith("~$") || name.EndsWith(".tmp", StringComparison.OrdinalIgnoreCase))
            return false;

        return ScanExtensions.Contains(Path.GetExtension(path));
    }
}
