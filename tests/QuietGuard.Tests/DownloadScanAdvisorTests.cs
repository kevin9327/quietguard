using QuietGuard;

namespace QuietGuard.Tests;

public class DownloadScanAdvisorTests
{
    [Theory]
    [InlineData(@"C:\Users\a\Downloads\setup.exe")]
    [InlineData(@"C:\Users\a\Downloads\photo.jpg")]
    [InlineData(@"C:\Users\a\Downloads\payload.tmp")]
    public void ShouldQueue_matches_DownloadWatchFilter(string path)
    {
        Assert.Equal(DownloadWatchFilter.ShouldScan(path), DownloadScanAdvisor.ShouldQueue(path));
    }

    [Fact]
    public void ShouldQueue_exe_true_jpg_false_tmp_false()
    {
        var exe = @"C:\Users\a\Downloads\setup.exe";
        var jpg = @"C:\Users\a\Downloads\photo.jpg";
        var tmp = @"C:\Users\a\Downloads\payload.tmp";

        Assert.True(DownloadWatchFilter.ShouldScan(exe));
        Assert.True(DownloadScanAdvisor.ShouldQueue(exe));

        Assert.False(DownloadWatchFilter.ShouldScan(jpg));
        Assert.False(DownloadScanAdvisor.ShouldQueue(jpg));

        Assert.False(DownloadWatchFilter.ShouldScan(tmp));
        Assert.False(DownloadScanAdvisor.ShouldQueue(tmp));
    }

    [Fact]
    public void ShouldNotify_quiet_on_zero_nonzero_notifies()
    {
        Assert.False(DownloadScanAdvisor.ShouldNotify(0));
        Assert.True(DownloadScanAdvisor.ShouldNotify(2));
    }

    [Fact]
    public void FormatResult_uses_file_name_not_full_path()
    {
        var path = @"C:\Users\a\Downloads\setup.exe";

        var clean = DownloadScanAdvisor.FormatResult(path, 0);
        var dirty = DownloadScanAdvisor.FormatResult(path, 2);

        Assert.Equal("다운로드 검사 완료: setup.exe", clean);
        Assert.Equal("다운로드 검사 코드 2: setup.exe", dirty);
        Assert.DoesNotContain(path, clean);
        Assert.DoesNotContain(path, dirty);
        Assert.Contains("setup.exe", clean);
        Assert.Contains("setup.exe", dirty);
    }
}
