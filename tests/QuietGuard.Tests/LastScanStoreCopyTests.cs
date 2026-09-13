using QuietGuard;

namespace QuietGuard.Tests;

public class LastScanStoreCopyTests
{
    [Fact]
    public void Parse_empty_is_null_and_equals_store()
    {
        Assert.Null(LastScanStoreCopy.Parse(null));
        Assert.Equal(LastScanStore.Parse(null), LastScanStoreCopy.Parse(null));
        Assert.Null(LastScanStoreCopy.Parse(""));
        Assert.Equal(LastScanStore.Parse(""), LastScanStoreCopy.Parse(""));
    }

    [Fact]
    public void Format_roundtrips_through_parse()
    {
        var utc = new DateTime(2026, 9, 13, 12, 0, 0, DateTimeKind.Utc);
        var formatted = LastScanStoreCopy.Format(utc);
        Assert.Equal(LastScanStore.Format(utc), formatted);
        Assert.Equal(utc, LastScanStoreCopy.Parse(formatted));
        Assert.Equal(LastScanStore.Parse(formatted), LastScanStoreCopy.Parse(formatted));
    }

    [Fact]
    public void FilePath_ends_with_last_quick_scan_file()
    {
        Assert.EndsWith("last-quick-scan-utc.txt", LastScanStoreCopy.FilePath);
        Assert.Equal(LastScanStore.FilePath, LastScanStoreCopy.FilePath);
    }
}
