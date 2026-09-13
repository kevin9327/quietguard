namespace QuietGuard;

public static class ServiceHeadlineCopy
{
    public static string Headline(bool running) => ServiceHealthCopy.Headline(running);

    public static bool IsQuiet(bool running) => ServiceHealthCopy.IsQuiet(running);
}
