namespace QuietGuard;

public static class PathSafetyCopy
{
    public static bool IsSafe(string path) => ScanPathSafety.IsSafeCustomScanTarget(path);

    public static string Headline(string path) =>
        IsSafe(path) ? "검사 가능한 경로" : "Windows 경로는 검사하지 않습니다";
}
