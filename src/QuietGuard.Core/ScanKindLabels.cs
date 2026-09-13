namespace QuietGuard;

public static class ScanKindLabels
{
    public static string Name(ScanKind kind) => kind switch
    {
        ScanKind.Quick => "빠른 검사",
        ScanKind.Full => "전체 검사",
        ScanKind.CustomFile => "파일 검사",
        _ => kind.ToString()
    };
}
