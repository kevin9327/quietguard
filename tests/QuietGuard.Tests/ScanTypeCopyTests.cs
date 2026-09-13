using QuietGuard;

namespace QuietGuard.Tests;

public class ScanTypeCopyTests
{
    [Fact]
    public void For_quick_equals_scan_type_1_and_quick_scan_copy()
    {
        Assert.Equal("-Scan -ScanType 1", ScanTypeCopy.For(ScanKind.Quick));
        Assert.Equal(ScanTypeArgs.For(ScanKind.Quick), ScanTypeCopy.For(ScanKind.Quick));
        Assert.Equal(QuickScanCopy.Arguments(), ScanTypeCopy.For(ScanKind.Quick));
    }

    [Fact]
    public void For_full_equals_scan_type_2_and_full_scan_copy()
    {
        Assert.Equal("-Scan -ScanType 2", ScanTypeCopy.For(ScanKind.Full));
        Assert.Equal(FullScanCopy.Arguments(), ScanTypeCopy.For(ScanKind.Full));
    }

    [Fact]
    public void For_custom_file_throws()
    {
        Assert.Throws<ArgumentException>(() => ScanTypeCopy.For(ScanKind.CustomFile));
    }

    [Fact]
    public void ForFile_quotes_path_and_matches_ScanTypeArgs()
    {
        var path = @"C:\Users\a\Downloads\setup.exe";
        Assert.Equal(ScanTypeArgs.ForFile(path), ScanTypeCopy.ForFile(path));
        Assert.Contains("\"" + path + "\"", ScanTypeCopy.ForFile(path));
    }

    [Fact]
    public void ForFile_empty_throws()
    {
        Assert.Throws<ArgumentException>(() => ScanTypeCopy.ForFile(""));
    }
}
