using QuietGuard;

namespace QuietGuard.Tests;

public class DownloadScanCopyTests
{
    [Fact]
    public void Clean_exit_does_not_notify_and_formats_complete()
    {
        const string path = @"C:\Users\a\Downloads\setup.exe";
        Assert.False(DownloadScanCopy.ShouldNotify(0));
        Assert.Equal(DownloadScanAdvisor.ShouldNotify(0), DownloadScanCopy.ShouldNotify(0));
        Assert.Equal("다운로드 검사 완료: setup.exe", DownloadScanCopy.FormatResult(path, 0));
        Assert.Equal(DownloadScanAdvisor.FormatResult(path, 0), DownloadScanCopy.FormatResult(path, 0));
    }

    [Fact]
    public void Threat_exit_notifies_and_includes_code()
    {
        const string path = @"C:\Users\a\Downloads\payload.exe";
        Assert.True(DownloadScanCopy.ShouldNotify(2));
        Assert.Equal(DownloadScanAdvisor.ShouldNotify(2), DownloadScanCopy.ShouldNotify(2));
        Assert.Equal("다운로드 검사 코드 2: payload.exe", DownloadScanCopy.FormatResult(path, 2));
        Assert.Equal(DownloadScanAdvisor.FormatResult(path, 2), DownloadScanCopy.FormatResult(path, 2));
    }

    [Fact]
    public void Debounce_equals_advisor_1500ms()
    {
        Assert.Equal(TimeSpan.FromMilliseconds(1500), DownloadScanCopy.Debounce);
        Assert.Equal(DownloadScanAdvisor.Debounce, DownloadScanCopy.Debounce);
    }
}
