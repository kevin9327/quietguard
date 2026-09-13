namespace QuietGuard;

public static class ThreatStateCopy
{
    public static string Headline(string? state) => ThreatStateText.Describe(state);

    public static string Headline(ThreatInfo threat) => ThreatStateText.Describe(threat);
}
