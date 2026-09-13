namespace QuietGuard;

public static class ThreatButtonStack
{
    public static IReadOnlyList<string> Labels() =>
    [
        RestoreCopy.Button(),
        AllowCopy.Button(),
        RemediateCopy.Button()
    ];
}
