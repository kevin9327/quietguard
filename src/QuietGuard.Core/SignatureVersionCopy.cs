namespace QuietGuard;

public static class SignatureVersionCopy
{
    public static string Headline(string? version) => SignatureVersionText.Format(version);

    public static string Headline(DefenderStatus status) => SignatureVersionText.Format(status);
}
