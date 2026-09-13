namespace QuietGuard;

public static class UpdateNowCopy
{
    public static string Button() => "정의 업데이트";
    public static string QuietStatus() => "정의를 조용히 갱신합니다";
    public static string AlertStatus() => "정의가 오래되어 업데이트가 필요합니다";

    public static string Status(bool signaturesOutOfDate, TimeSpan? age)
    {
        if (!DefinitionUpdateAdvisor.ShouldUpdate(signaturesOutOfDate, age))
            return "정의가 최신입니다";
        return DefinitionUpdateAdvisor.ShouldNotifyAboutUpdate(signaturesOutOfDate, age)
            ? AlertStatus()
            : QuietStatus();
    }
}
