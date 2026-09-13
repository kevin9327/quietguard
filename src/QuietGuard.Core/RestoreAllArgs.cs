namespace QuietGuard;

public static class RestoreAllArgs
{
    public static string All() => "-Restore -All";

    // File restore must match ThreatActions.Plan(Restore).Arguments for the same path.
    public static string File(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException("path");
        return $"-Restore -FilePath \"{path}\"";
    }
}
