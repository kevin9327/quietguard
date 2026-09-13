namespace QuietGuard;

public static class PathExclusionCopy
{
    public static bool IsExcluded(string filePath, IReadOnlyList<string> exclusions) =>
        PathExclusion.IsExcluded(filePath, exclusions);

    public static IReadOnlyList<string> Defaults() => PathExclusion.DefaultQuietExclusions();

    public static bool IsQuietDefault(string filePath) =>
        PathExclusion.IsExcluded(filePath, PathExclusion.DefaultQuietExclusions());
}
