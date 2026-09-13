namespace QuietGuard;

public static class PathSafeHeadlineCopy
{
    public static bool IsSafe(string path) => PathSafetyCopy.IsSafe(path);

    public static string Headline(string path) => PathSafetyCopy.Headline(path);
}
