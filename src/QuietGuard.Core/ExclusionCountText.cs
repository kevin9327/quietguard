namespace QuietGuard;

public static class ExclusionCountText
{
    public static string Format(int count) =>
        count <= 0 ? "제외 경로 없음" : $"제외 경로 {count}개";

    public static string FormatDefault() => Format(PathExclusion.DefaultQuietExclusions().Count);
}
