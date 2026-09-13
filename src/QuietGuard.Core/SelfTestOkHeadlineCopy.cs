namespace QuietGuard;

public static class SelfTestOkHeadlineCopy
{
    public static string Ok() => SelfTestOkCopy.Ok();

    public static string Fail(string message) => SelfTestOkCopy.Fail(message);
}
