using QuietGuard;

namespace QuietGuard.Tests;

public class DownloadWatchFilterTests
{
    [Theory]
    [InlineData(@"C:\Users\a\Downloads\setup.exe", true)]
    [InlineData(@"C:\Users\a\Downloads\payload.dll", true)]
    [InlineData(@"C:\Users\a\Downloads\macro.vbs", true)]
    [InlineData(@"C:\Users\a\Downloads\script.ps1", true)]
    [InlineData(@"C:\Users\a\Downloads\photo.jpg", false)]
    [InlineData(@"C:\Users\a\Downloads\notes.txt", false)]
    [InlineData(@"C:\Users\a\Downloads\video.mp4", false)]
    [InlineData(@"C:\Users\a\Downloads\~wrd0000.tmp", false)]
    [InlineData("", false)]
    public void Filters_risky_downloads_only(string path, bool expected)
    {
        Assert.Equal(expected, DownloadWatchFilter.ShouldScan(path));
    }
}
