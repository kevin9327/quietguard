namespace QuietGuard;

public static class BootStartCopy
{
    public static string Checkbox() => "시작 시 실행";

    public static bool MatchesRegistration(bool userOptIn, ProtectionLevel level) =>
        StartupRegistration.ShouldEnableAtBoot(userOptIn, level) == userOptIn;
}
