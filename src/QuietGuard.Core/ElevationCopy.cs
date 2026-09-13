namespace QuietGuard;

public static class ElevationCopy
{
    public static bool NeedsAdmin(ThreatActionKind kind) => ElevationPolicy.RequiresElevation(kind);

    public static string Headline(ThreatActionKind kind) =>
        NeedsAdmin(kind) ? "관리자 권한 필요" : "일반 권한으로 실행";
}
