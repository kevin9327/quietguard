namespace QuietGuard;

public static class UpdateNowHeadlineCopy
{
    public static string Button() => UpdateNowCopy.Button();

    public static string QuietStatus() => UpdateNowCopy.QuietStatus();

    public static string AlertStatus() => UpdateNowCopy.AlertStatus();

    public static string Status(bool signaturesOutOfDate, TimeSpan? age) =>
        UpdateNowCopy.Status(signaturesOutOfDate, age);
}
