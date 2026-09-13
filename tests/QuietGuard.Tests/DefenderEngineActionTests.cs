using QuietGuard;

namespace QuietGuard.Tests;

public class DefenderEngineActionTests
{
    [Fact]
    public async Task ApplyAsync_uses_ThreatActions_and_rejects_empty_restore()
    {
        var engine = new DefenderEngine();
        var empty = new ThreatInfo("", "", "", null);

        await Assert.ThrowsAsync<ArgumentException>(() =>
            engine.ApplyAsync(ThreatActionKind.Restore, empty));
    }

    [Fact]
    public async Task ScanFileAsync_skips_unsafe_windows_paths()
    {
        var engine = new DefenderEngine();
        var code = await engine.ScanFileAsync(@"C:\Windows\notepad.exe");
        Assert.Equal(0, code);
        Assert.False(DownloadScanAdvisor.ShouldQueue(@"C:\Windows\notepad.exe"));
    }

    [Fact]
    public void Scheduled_scan_arguments_match_quiet_scheduler()
    {
        Assert.Equal(
            "-Scan -ScanType 1",
            ScanScheduler.MpCmdArgumentsForScheduledQuickScan());
    }
}
