namespace QuietGuard;

public static class PathExclusion
{
    // true if filePath is under any exclusion folder (ordinal ignore case).
    // empty/null filePath -> false
    // skip null/whitespace exclusion entries
    // A file is excluded if it equals an exclusion path OR starts with exclusion + directory separator
    public static bool IsExcluded(string filePath, IReadOnlyList<string> exclusions)
    {
        if (string.IsNullOrEmpty(filePath))
            return false;

        foreach (var exclusion in exclusions)
        {
            if (string.IsNullOrWhiteSpace(exclusion))
                continue;

            if (filePath.Equals(exclusion, StringComparison.OrdinalIgnoreCase))
                return true;

            if (filePath.StartsWith(exclusion + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
                return true;
        }

        return false;
    }

    public static IReadOnlyList<string> DefaultQuietExclusions() =>
    [
        Environment.GetFolderPath(Environment.SpecialFolder.Windows),
        Environment.SystemDirectory
    ];
}
