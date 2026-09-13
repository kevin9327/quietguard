namespace QuietGuard;

public static class AllowCopy
{
    public static string Button() => ThreatActionLabels.Button(ThreatActionKind.Allow);

    public static string Arguments(ThreatInfo threat) => AllowThreatArgs.For(threat);

    public static int ActionId => PreferenceActionText.AllowId;
}
