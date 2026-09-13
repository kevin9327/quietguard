namespace QuietGuard;

public static class ScanElapsedText
{
    public static string Format(TimeSpan elapsed)
    {
        if (elapsed < TimeSpan.Zero) elapsed = TimeSpan.Zero;
        if (elapsed.TotalHours >= 1)
            return $"{(int)elapsed.TotalHours}시간 {elapsed.Minutes}분";
        if (elapsed.TotalMinutes >= 1)
            return $"{(int)elapsed.TotalMinutes}분 {elapsed.Seconds}초";
        return $"{elapsed.Seconds}초";
    }

    public static string WithPercent(TimeSpan elapsed, TimeSpan typical) =>
        $"{Format(elapsed)} · {ScanProgressEstimate.Percent(elapsed, typical)}%";
}
