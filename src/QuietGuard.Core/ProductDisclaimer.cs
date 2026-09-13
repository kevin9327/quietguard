namespace QuietGuard;

public static class ProductDisclaimer
{
    public const string Engine = "Microsoft Defender";
    public const string NotAhnLab = "AhnLab V3 코드나 이름을 사용하지 않습니다.";

    public static string Footer() =>
        $"엔진은 {Engine}입니다. 광고 없음. {NotAhnLab}";
}
