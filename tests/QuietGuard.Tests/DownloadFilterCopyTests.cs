using QuietGuard;

namespace QuietGuard.Tests;

public class DownloadFilterCopyTests
{
    [Fact]
    public void Setup_exe_is_scan_target_and_equals_filter()
    {
        const string path = @"C:\Users\a\Downloads\setup.exe";
        Assert.True(DownloadFilterCopy.ShouldScan(path));
        Assert.Equal(DownloadWatchFilter.ShouldScan(path), DownloadFilterCopy.ShouldScan(path));
        Assert.Equal("검사 대상", DownloadFilterCopy.Headline(path));
    }

    [Fact]
    public void Photo_jpg_is_skipped_and_equals_filter()
    {
        const string path = @"C:\Users\a\Downloads\photo.jpg";
        Assert.False(DownloadFilterCopy.ShouldScan(path));
        Assert.Equal(DownloadWatchFilter.ShouldScan(path), DownloadFilterCopy.ShouldScan(path));
        Assert.Equal("건너뜀", DownloadFilterCopy.Headline(path));
    }

    [Fact]
    public void Word_tmp_and_empty_are_skipped()
    {
        Assert.False(DownloadFilterCopy.ShouldScan(@"C:\Users\a\Downloads\~wrd0000.tmp"));
        Assert.Equal(
            DownloadWatchFilter.ShouldScan(@"C:\Users\a\Downloads\~wrd0000.tmp"),
            DownloadFilterCopy.ShouldScan(@"C:\Users\a\Downloads\~wrd0000.tmp"));
        Assert.False(DownloadFilterCopy.ShouldScan(""));
        Assert.Equal(DownloadWatchFilter.ShouldScan(""), DownloadFilterCopy.ShouldScan(""));
    }
}
