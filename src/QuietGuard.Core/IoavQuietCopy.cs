namespace QuietGuard;

public static class IoavQuietCopy
{
    public static bool IsQuiet(bool ioavEnabled) => IoavProtectionCopy.IsQuiet(ioavEnabled);

    public static string Headline(bool ioavEnabled) => IoavProtectionCopy.Headline(ioavEnabled);
}
