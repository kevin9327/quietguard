namespace QuietGuard;

public static class ThreatListPresentation
{
    public static string EmptyListPlaceholder => "최근 위협 없음";

    public static string FormatRow(ThreatInfo threat)
    {
        var stamp = threat.DetectedAt is { } detected
            ? detected.ToLocalTime().ToString("MM-dd HH:mm")
            : "--:--";
        return $"{stamp}  {threat.Name}  {threat.Path}";
    }

    public static bool IsSelectableIndex(int index, int threatCount) =>
        index >= 0 && index < threatCount;

    public static IReadOnlyList<ThreatActionKind> AvailableActions(ThreatInfo threat)
    {
        ThreatActionKind[] candidates =
        [
            ThreatActionKind.Restore,
            ThreatActionKind.Allow,
            ThreatActionKind.Remediate
        ];

        return candidates.Where(kind => ThreatActions.CanAct(kind, threat)).ToArray();
    }
}
