using QuietGuard;

namespace QuietGuard.Tests;

public class WinDefendCopyTests
{
    [Fact]
    public void Service_and_command_line_match_names()
    {
        Assert.Equal("WinDefend", WinDefendCopy.Service);
        Assert.Equal(WinDefendNames.Service, WinDefendCopy.Service);
        Assert.Equal("MpCmdRun.exe", WinDefendCopy.CommandLine);
        Assert.Equal(WinDefendNames.CommandLine, WinDefendCopy.CommandLine);
        Assert.Equal("MsMpEng", WinDefendCopy.EngineProcess);
        Assert.Equal(WinDefendNames.EngineProcess, WinDefendCopy.EngineProcess);
    }

    [Fact]
    public void IsEngineProcess_matches_names_ignore_case()
    {
        Assert.True(WinDefendCopy.IsEngineProcess("MsMpEng"));
        Assert.True(WinDefendCopy.IsEngineProcess("msmpeng"));
        Assert.False(WinDefendCopy.IsEngineProcess("QuietGuard"));
        Assert.False(WinDefendCopy.IsEngineProcess(null));
        Assert.Equal(WinDefendNames.IsEngineProcess("MsMpEng"), WinDefendCopy.IsEngineProcess("MsMpEng"));
    }

    [Fact]
    public void IsCommandLine_matches_filename_only()
    {
        const string full = @"C:\Program Files\Windows Defender\MpCmdRun.exe";
        Assert.True(WinDefendCopy.IsCommandLine(full));
        Assert.True(WinDefendCopy.IsCommandLine("MpCmdRun.exe"));
        Assert.False(WinDefendCopy.IsCommandLine("powershell.exe"));
        Assert.Equal(WinDefendNames.IsCommandLine(full), WinDefendCopy.IsCommandLine(full));
    }
}
