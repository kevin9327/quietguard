namespace QuietGuard;

public static class ScanPathSafety
{
    // false if null/whitespace
    // false if path contains "..\" or "../" or is relative
    // false if rooted path is under Environment.GetFolderPath(Windows) OR under Environment.SystemDirectory (case-insensitive, trailing slash insensitive)
    // true for a normal user Downloads file like C:\Users\a\Downloads\setup.exe
    public static bool IsSafeCustomScanTarget(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return false;

        if (path.Contains(@"..\", StringComparison.Ordinal) ||
            path.Contains("../", StringComparison.Ordinal))
            return false;

        if (!Path.IsPathRooted(path))
            return false;

        string fullPath;
        try
        {
            fullPath = Path.GetFullPath(path);
        }
        catch
        {
            return false;
        }

        var windows = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
        var systemDirectory = Environment.SystemDirectory;
        if (IsUnderDirectory(fullPath, windows) || IsUnderDirectory(fullPath, systemDirectory))
            return false;

        return true;
    }

    static bool IsUnderDirectory(string fullPath, string directory)
    {
        if (string.IsNullOrWhiteSpace(directory))
            return false;

        string fullDirectory;
        try
        {
            fullDirectory = Path.GetFullPath(directory);
        }
        catch
        {
            return false;
        }

        var candidate = Path.TrimEndingDirectorySeparator(fullPath);
        var root = Path.TrimEndingDirectorySeparator(fullDirectory);
        if (candidate.Equals(root, StringComparison.OrdinalIgnoreCase))
            return true;

        return candidate.StartsWith(root + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase);
    }
}
