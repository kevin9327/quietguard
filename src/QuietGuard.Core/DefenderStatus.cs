namespace QuietGuard;

public sealed record DefenderStatus(
    bool AntivirusEnabled,
    bool RealTimeProtectionEnabled,
    bool IoavProtectionEnabled,
    bool BehaviorMonitorEnabled,
    bool NisEnabled,
    bool IsTamperProtected,
    bool SignaturesOutOfDate,
    DateTime? AntivirusSignatureLastUpdated,
    DateTime? LastQuickScanTime,
    DateTime? LastFullScanTime,
    string? EngineVersion,
    string? SignatureVersion,
    string? ProductStatus)
{
    public TimeSpan? SignatureAge =>
        AntivirusSignatureLastUpdated is { } updated
            ? DateTime.Now - updated
            : null;
}

public sealed record ThreatInfo(
    string Name,
    string Path,
    string State,
    DateTime? DetectedAt);

public sealed record EngineBudget(
    float DefenderCpuPercent,
    long DefenderWorkingSetBytes,
    float AppCpuPercent,
    long AppWorkingSetBytes);

public enum ProtectionLevel
{
    Protected,
    Attention,
    Unprotected
}

public sealed record ProtectionVerdict(
    ProtectionLevel Level,
    string Headline,
    IReadOnlyList<string> Reasons);
