namespace QuietGuard;

public static class ThreatListCopy
{
    public static string Placeholder() => ThreatListPresentation.EmptyListPlaceholder;

    public static string FormatRow(ThreatInfo threat) => ThreatListPresentation.FormatRow(threat);

    public static bool IsSelectable(int index, int threatCount) =>
        ThreatListPresentation.IsSelectableIndex(index, threatCount);
}
