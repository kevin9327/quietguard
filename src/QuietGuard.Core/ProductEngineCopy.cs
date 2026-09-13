namespace QuietGuard;

public static class ProductEngineCopy
{
    public static string Name() => ProductDisclaimer.Engine;

    public static string Line() => SelfTestBanner.EngineLine();

    public static bool IsDefender() =>
        string.Equals(Name(), "Microsoft Defender", StringComparison.Ordinal);
}
