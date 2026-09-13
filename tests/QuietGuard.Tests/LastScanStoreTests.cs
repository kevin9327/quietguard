using QuietGuard;

namespace QuietGuard.Tests;

public class LastScanStoreTests
{
    [Fact]
    public void Parse_roundtrips_formatted_utc()
    {
        var utc = new DateTime(2026, 9, 13, 14, 50, 0, DateTimeKind.Utc);
        var text = LastScanStore.Format(utc);
        var parsed = LastScanStore.Parse(text);

        Assert.NotNull(parsed);
        Assert.Equal(utc, parsed);
        Assert.Contains("2026-09-13", text);
    }

    [Fact]
    public void Parse_blank_or_garbage_is_null()
    {
        Assert.Null(LastScanStore.Parse(null));
        Assert.Null(LastScanStore.Parse(""));
        Assert.Null(LastScanStore.Parse("   "));
        Assert.Null(LastScanStore.Parse("not-a-date"));
    }

    [Fact]
    public void FilePath_is_under_QuietGuard_appdata()
    {
        Assert.Contains("QuietGuard", LastScanStore.FilePath);
        Assert.EndsWith("last-quick-scan-utc.txt", LastScanStore.FilePath);
    }
}
