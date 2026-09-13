using QuietGuard;

namespace QuietGuard.Tests;

public class WinDefendNamesTests
{
    [Fact]
    public void Engine_process_matches_MsMpEng_ignore_case()
    {
        Assert.True(WinDefendNames.IsEngineProcess("MsMpEng"));
        Assert.True(WinDefendNames.IsEngineProcess("msmpeng"));
        Assert.False(WinDefendNames.IsEngineProcess("QuietGuard"));
        Assert.False(WinDefendNames.IsEngineProcess(null));
    }

    [Fact]
    public void Command_line_matches_filename_only()
    {
        Assert.True(WinDefendNames.IsCommandLine(@"C:\Program Files\Windows Defender\MpCmdRun.exe"));
        Assert.True(WinDefendNames.IsCommandLine("MpCmdRun.exe"));
        Assert.False(WinDefendNames.IsCommandLine("powershell.exe"));
        Assert.Equal("MpCmdRun.exe", WinDefendNames.CommandLine);
        Assert.Equal("WinDefend", WinDefendNames.Service);
    }
}
