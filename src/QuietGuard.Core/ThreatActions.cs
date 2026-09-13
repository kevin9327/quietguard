namespace QuietGuard;

public enum ThreatActionKind
{
    Restore,
    Allow,
    Remediate
}

public sealed record ThreatActionPlan(
    ThreatActionKind Kind,
    string FileName,
    string Arguments,
    bool RequiresElevation,
    bool NotifyUser,
    string Summary);

public static class ThreatActions
{
    public static ThreatActionPlan Plan(ThreatActionKind kind, ThreatInfo threat)
    {
        if (!CanAct(kind, threat))
            throw new ArgumentException("이 위협에는 해당 조치를 적용할 수 없습니다.");

        return kind switch
        {
            ThreatActionKind.Restore => new ThreatActionPlan(
                ThreatActionKind.Restore,
                "MpCmdRun.exe",
                $"-Restore -FilePath {Quote(threat.Path)}",
                RequiresElevation: true,
                NotifyUser: true,
                Summary: $"검역소에서 {Quote(threat.Path)}을(를) 복원합니다."),
            ThreatActionKind.Allow => AllowPlan(threat),
            ThreatActionKind.Remediate => new ThreatActionPlan(
                ThreatActionKind.Remediate,
                "MpCmdRun.exe",
                $"-Scan -ScanType 3 -File {Quote(threat.Path)}",
                RequiresElevation: false,
                NotifyUser: true,
                Summary: $"{Quote(threat.Path)}을(를) Microsoft Defender로 다시 검사합니다."),
            _ => throw new ArgumentException("지원하지 않는 조치입니다.", nameof(kind))
        };
    }

    public static bool CanAct(ThreatActionKind kind, ThreatInfo threat)
    {
        if (threat is null || !Enum.IsDefined(kind))
            return false;

        return kind switch
        {
            ThreatActionKind.Restore => HasPath(threat),
            ThreatActionKind.Allow => HasName(threat) || HasPath(threat),
            ThreatActionKind.Remediate => HasPath(threat),
            _ => false
        };
    }

    private static ThreatActionPlan AllowPlan(ThreatInfo threat)
    {
        var id = LooksLikeThreatId(threat.Name) ? threat.Name.Trim() : threat.Path;
        var idArgument = LooksLikeThreatId(id) ? id : $"'{id}'";

        return new ThreatActionPlan(
            ThreatActionKind.Allow,
            "powershell.exe",
            $"-NoProfile -Command \"Add-MpPreference -ThreatIDDefaultAction_Ids {idArgument} -ThreatIDDefaultAction_Actions Allow\"",
            RequiresElevation: true,
            NotifyUser: true,
            Summary: $"위협 {id}을(를) 허용 목록에 추가합니다.");
    }

    private static bool HasPath(ThreatInfo threat) => !string.IsNullOrWhiteSpace(threat.Path);

    private static bool HasName(ThreatInfo threat) => !string.IsNullOrWhiteSpace(threat.Name);

    private static bool LooksLikeThreatId(string? value) =>
        !string.IsNullOrWhiteSpace(value) && long.TryParse(value.Trim(), out _);

    private static string Quote(string value) => $"\"{value}\"";
}
