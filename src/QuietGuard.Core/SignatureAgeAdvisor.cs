namespace QuietGuard;

public static class SignatureAgeAdvisor
{
    public static readonly TimeSpan DefaultLimit = ProtectionAdvisor.SignatureStaleAfter;

    public static bool IsStale(TimeSpan? age, TimeSpan? limit = null)
    {
        var cap = limit ?? DefaultLimit;
        return age is { } value && value > cap;
    }

    public static string FormatAge(TimeSpan? age)
    {
        if (age is not { } value)
            return "정의 시각 없음";
        if (value < TimeSpan.Zero)
            return "정의 시각 없음";
        if (value.TotalHours < 1)
            return $"{Math.Max(0, (int)value.TotalMinutes)}분 전";
        if (value.TotalDays < 1)
            return $"{(int)value.TotalHours}시간 전";
        return $"{(int)value.TotalDays}일 전";
    }
}
