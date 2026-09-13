namespace QuietGuard;

public static class PathExclusionHeadlineCopy
{
    public static bool IsExcluded(string filePath, IReadOnlyList<string> exclusions) =>
        PathExclusionCopy.IsExcluded(filePath, exclusions);

    public static IReadOnlyList<string> Defaults() => PathExclusionCopy.Defaults();

    public static bool IsQuietDefault(string filePath) =>
        PathExclusionCopy.IsQuietDefault(filePath);
}
