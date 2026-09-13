namespace QuietGuard;

public static class StatusTileCopy
{
    public static IReadOnlyList<string> From(DefenderStatus status) => StatusTileStack.From(status);
}
