namespace QuietGuard;

public static class ThreatStateHeadlineCopy
{
    public static string Headline(string? state) => ThreatStateCopy.Headline(state);

    public static string Headline(ThreatInfo threat) => ThreatStateCopy.Headline(threat);
}
