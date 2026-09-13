using QuietGuard;

namespace QuietGuard.Tests;

public class QueueHeadlineCopyTests
{
    [Fact]
    public void Setup_exe_in_downloads_queues_and_headlines_wait()
    {
        var path = @"C:\Users\a\Downloads\setup.exe";

        Assert.True(QueueHeadlineCopy.ShouldQueue(path));
        Assert.Equal("다운로드 검사 대기", QueueHeadlineCopy.Headline(path));
        Assert.Equal(DownloadQueueCopy.ShouldQueue(path), QueueHeadlineCopy.ShouldQueue(path));
        Assert.Equal(DownloadQueueCopy.Headline(path), QueueHeadlineCopy.Headline(path));
        Assert.Equal(DownloadScanAdvisor.ShouldQueue(path), QueueHeadlineCopy.ShouldQueue(path));
    }

    [Fact]
    public void Windows_notepad_is_not_queued()
    {
        var path = @"C:\Windows\notepad.exe";

        Assert.False(QueueHeadlineCopy.ShouldQueue(path));
        Assert.Equal("검사 대상 아님", QueueHeadlineCopy.Headline(path));
        Assert.Equal(DownloadQueueCopy.ShouldQueue(path), QueueHeadlineCopy.ShouldQueue(path));
        Assert.Equal(DownloadQueueCopy.Headline(path), QueueHeadlineCopy.Headline(path));
    }
}
