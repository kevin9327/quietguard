using QuietGuard;

namespace QuietGuard.Tests;

public class DownloadQueueCopyTests
{
    [Fact]
    public void Setup_exe_in_downloads_queues_and_headlines_wait()
    {
        var path = @"C:\Users\a\Downloads\setup.exe";

        Assert.True(DownloadWatchFilter.ShouldScan(path));
        Assert.Equal(DownloadWatchFilter.ShouldScan(path), DownloadQueueCopy.ShouldQueue(path));
        Assert.Equal(DownloadScanAdvisor.ShouldQueue(path), DownloadQueueCopy.ShouldQueue(path));
        Assert.True(DownloadQueueCopy.ShouldQueue(path));
        Assert.Equal("다운로드 검사 대기", DownloadQueueCopy.Headline(path));
    }

    [Fact]
    public void Photo_jpg_is_not_queued()
    {
        var path = @"C:\Users\a\Downloads\photo.jpg";

        Assert.False(DownloadWatchFilter.ShouldScan(path));
        Assert.Equal(DownloadWatchFilter.ShouldScan(path), DownloadQueueCopy.ShouldQueue(path));
        Assert.Equal(DownloadScanAdvisor.ShouldQueue(path), DownloadQueueCopy.ShouldQueue(path));
        Assert.False(DownloadQueueCopy.ShouldQueue(path));
        Assert.Equal("검사 대상 아님", DownloadQueueCopy.Headline(path));
    }
}
