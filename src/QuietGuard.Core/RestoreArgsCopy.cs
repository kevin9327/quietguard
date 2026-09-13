namespace QuietGuard;

public static class RestoreArgsCopy
{
    public static string All() => RestoreAllArgs.All();

    public static string File(string path) => RestoreAllArgs.File(path);
}
