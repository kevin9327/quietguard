namespace QuietGuard;

public static class SelfTestOkCopy
{
    public static string Ok() => SelfTestBanner.Ok();
    public static string Fail(string message) => SelfTestBanner.Fail(message);
    public static string MpCmdName() => SelfTestBanner.CommandLineName();
}
