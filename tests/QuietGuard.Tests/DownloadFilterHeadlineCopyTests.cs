using QuietGuard;

namespace QuietGuard.Tests;

public class DownloadFilterHeadlineCopyTests
{
    [Fact]
    public void Setup_exe_is_scan_target_and_equals_copy_and_filter()
    {
        const string path = @"C:\Users\a\Downloads\setup.exe";

        Assert.True(DownloadFilterHeadlineCopy.ShouldScan(path));
        Assert.Equal("검사 대상", DownloadFilterHeadlineCopy.Headline(path));
        Assert.Equal(DownloadFilterCopy.ShouldScan(path), DownloadFilterHeadlineCopy.ShouldScan(path));
        Assert.Equal(DownloadFilterCopy.Headline(path), DownloadFilterHeadlineCopy.Headline(path));
        Assert.Equal(DownloadWatchFilter.ShouldScan(path), DownloadFilterHeadlineCopy.ShouldScan(path));
    }

    [Fact]
    public void Photo_jpg_is_skipped_and_equals_copy_and_filter()
    {
        const string path = @"C:\Users\a\Downloads\photo.jpg";

        Assert.False(DownloadFilterHeadlineCopy.ShouldScan(path));
        Assert.Equal("건너뜀", DownloadFilterHeadlineCopy.Headline(path));
        Assert.Equal(DownloadFilterCopy.ShouldScan(path), DownloadFilterHeadlineCopy.ShouldScan(path));
        Assert.Equal(DownloadFilterCopy.Headline(path), DownloadFilterHeadlineCopy.Headline(path));
        Assert.Equal(DownloadWatchFilter.ShouldScan(path), DownloadFilterHeadlineCopy.ShouldScan(path));
    }
}
