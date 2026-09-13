using QuietGuard;

namespace QuietGuard.Tests;

public class ScanTypeArgsTests
{
    [Fact]
    public void For_quick_equals_scheduled_quick_scan_args()
    {
        Assert.Equal(
            ScanScheduler.MpCmdArgumentsForScheduledQuickScan(),
            ScanTypeArgs.For(ScanKind.Quick));
    }

    [Fact]
    public void For_full_is_scan_type_2()
    {
        Assert.Equal("-Scan -ScanType 2", ScanTypeArgs.For(ScanKind.Full));
    }

    [Fact]
    public void For_custom_file_throws()
    {
        Assert.Throws<ArgumentException>(() => ScanTypeArgs.For(ScanKind.CustomFile));
    }

    [Fact]
    public void ForFile_quotes_path_and_includes_scan_type_3()
    {
        var args = ScanTypeArgs.ForFile(@"C:\Users\a\Downloads\setup.exe");
        Assert.Contains("-ScanType 3", args);
        Assert.Equal(@"-Scan -ScanType 3 -File ""C:\Users\a\Downloads\setup.exe""", args);
    }

    [Fact]
    public void ForFile_empty_throws()
    {
        Assert.Throws<ArgumentException>(() => ScanTypeArgs.ForFile(""));
        Assert.Throws<ArgumentException>(() => ScanTypeArgs.ForFile("   "));
    }
}
