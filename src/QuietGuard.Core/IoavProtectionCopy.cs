namespace QuietGuard;

public static class IoavProtectionCopy
{
    public static string Headline(bool ioavEnabled) =>
        ioavEnabled ? "다운로드 파일 검사 켜짐" : "다운로드 파일 검사가 꺼져 있습니다";

    public static bool IsQuiet(bool ioavEnabled) => ioavEnabled;

    public static string Headline(DefenderStatus status) => Headline(status.IoavProtectionEnabled);
}
