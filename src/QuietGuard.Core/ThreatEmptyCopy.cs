namespace QuietGuard;

public static class ThreatEmptyCopy
{
    public static string Placeholder() => ThreatListPresentation.EmptyListPlaceholder;

    public static bool IsEmpty(int count) => count <= 0;

    public static string Headline(int count) =>
        IsEmpty(count) ? Placeholder() : ThreatCountText.Format(count);
}
