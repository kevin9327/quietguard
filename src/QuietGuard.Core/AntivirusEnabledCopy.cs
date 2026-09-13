namespace QuietGuard;

public static class AntivirusEnabledCopy
{
    public static string Headline(bool antivirusEnabled) =>
        antivirusEnabled ? "Microsoft Defender 백신 켜짐" : "Microsoft Defender 백신이 꺼져 있습니다";

    public static bool IsQuiet(bool antivirusEnabled) => antivirusEnabled;

    public static string Headline(DefenderStatus status) => Headline(status.AntivirusEnabled);

    public static bool IsQuiet(DefenderStatus status) => IsQuiet(status.AntivirusEnabled);
}
