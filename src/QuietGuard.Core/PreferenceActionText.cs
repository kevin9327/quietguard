namespace QuietGuard;

public static class PreferenceActionText
{
    // Defender Add-MpPreference ThreatIDDefaultAction_Actions values
    public static string Name(int actionId) => actionId switch
    {
        1 => "정리",
        2 => "격리",
        3 => "제거",
        6 => "허용",
        8 => "사용자 지정",
        9 => "차단",
        10 => "없음",
        _ => $"동작 {actionId}"
    };

    public static int AllowId => 6;
    public static bool IsAllow(int actionId) => actionId == AllowId;
}
