namespace QuietGuard;

public static class ScanButtonStack
{
    public static IReadOnlyList<string> Labels() =>
    [
        QuickScanCopy.Button(),
        FullScanCopy.Button(),
        CustomScanCopy.Button(),
        ScanCancelCopy.Button()
    ];
}
