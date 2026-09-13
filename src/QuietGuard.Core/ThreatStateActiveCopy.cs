namespace QuietGuard;

public static class ThreatStateActiveCopy
{
    public static string Active() => ThreatStateText.Describe("Active");

    public static string Removed() => ThreatStateText.Describe("Removed");

    public static string Quarantined() => ThreatStateText.Describe("Quarantined");
}
