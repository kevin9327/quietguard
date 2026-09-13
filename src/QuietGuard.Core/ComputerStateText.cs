namespace QuietGuard;

public static class ComputerStateText
{
    // Defender MSFT_MpComputerStatus ComputerState is a bitmask / numeric string.
    // 0 or "0" -> "정상"
    // null/whitespace -> "상태 없음"
    // anything else -> "상태 코드 {raw}"
    public static string Describe(string? productStatus)
    {
        if (string.IsNullOrWhiteSpace(productStatus))
            return "상태 없음";
        if (productStatus == "0")
            return "정상";
        return $"상태 코드 {productStatus}";
    }

    public static string Describe(DefenderStatus status) => Describe(status.ProductStatus);
}
