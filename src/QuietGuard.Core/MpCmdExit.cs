namespace QuietGuard;

public static class MpCmdExit
{
    public static bool IsClean(int code) => code == 0;

    public static bool IsThreatDetected(int code) => code == 2;

    public static string Describe(int code) => code switch
    {
        0 => "이상 없음",
        2 => "위협 발견",
        _ => $"종료 코드 {code}"
    };
}
