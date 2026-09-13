namespace QuietGuard;

public static class ExclusionHeadlineCopy
{
    public static string Headline(int count) => ExclusionCountText.Format(count);

    public static string DefaultHeadline() => ExclusionCountText.FormatDefault();
}
