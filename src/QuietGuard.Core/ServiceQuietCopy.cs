namespace QuietGuard;

public static class ServiceQuietCopy
{
    public static bool IsQuiet(bool running) => ServiceHealthCopy.IsQuiet(running);

    public static string Headline(bool running) => ServiceHealthCopy.Headline(running);
}
