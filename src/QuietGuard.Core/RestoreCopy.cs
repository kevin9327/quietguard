namespace QuietGuard;

public static class RestoreCopy
{
    public static string Button() => ThreatActionLabels.Button(ThreatActionKind.Restore);

    public static string FileArguments(string path) => RestoreAllArgs.File(path);

    public static string AllArguments() => RestoreAllArgs.All();
}
