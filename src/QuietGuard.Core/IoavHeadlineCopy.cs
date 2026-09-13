namespace QuietGuard;

public static class IoavHeadlineCopy
{
    public static bool IsQuiet(bool ioavEnabled) => IoavQuietCopy.IsQuiet(ioavEnabled);

    public static string Headline(bool ioavEnabled) => IoavQuietCopy.Headline(ioavEnabled);
}
