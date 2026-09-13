namespace QuietGuard;

public static class ThreatStateText
{
    // ThreatInfo.State is often a numeric ThreatStatusID or a word like Quarantined.
    // "Quarantined" / "6" -> "격리됨"
    // "Active" / "1" -> "활성"
    // "Removed" / "3" -> "제거됨"
    // null/whitespace -> "상태 없음"
    // else -> the original State trimmed
    public static string Describe(string? state)
    {
        if (string.IsNullOrWhiteSpace(state))
            return "상태 없음";

        var trimmed = state.Trim();
        return trimmed switch
        {
            "Quarantined" or "6" => "격리됨",
            "Active" or "1" => "활성",
            "Removed" or "3" => "제거됨",
            _ => trimmed
        };
    }

    public static string Describe(ThreatInfo threat) => Describe(threat.State);
}
