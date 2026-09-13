namespace QuietGuard;

public static class SelfTestBanner
{
    public static string Ok() => "quietguard.self-test=ok";
    public static string Fail(string message) => $"quietguard.self-test=fail {message}";
    public static string EngineLine() => $"engine-product={ProductDisclaimer.Engine}";
    public static string CommandLineName() => WinDefendNames.CommandLine;
}
