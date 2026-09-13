using QuietGuard;

namespace QuietGuard.Tests;

public class WinDefendHeadlineCopyTests
{
    [Fact]
    public void Service_and_command_line_match_copy_and_names()
    {
        Assert.Equal("WinDefend", WinDefendHeadlineCopy.Service);
        Assert.Equal(WinDefendCopy.Service, WinDefendHeadlineCopy.Service);
        Assert.Equal(WinDefendNames.Service, WinDefendHeadlineCopy.Service);
        Assert.Equal("MpCmdRun.exe", WinDefendHeadlineCopy.CommandLine);
        Assert.Equal(WinDefendCopy.CommandLine, WinDefendHeadlineCopy.CommandLine);
        Assert.Equal(WinDefendNames.CommandLine, WinDefendHeadlineCopy.CommandLine);
        Assert.Equal("MsMpEng", WinDefendHeadlineCopy.EngineProcess);
        Assert.Equal(WinDefendCopy.EngineProcess, WinDefendHeadlineCopy.EngineProcess);
        Assert.Equal(WinDefendNames.EngineProcess, WinDefendHeadlineCopy.EngineProcess);
    }

    [Fact]
    public void IsEngineProcess_matches_copy_and_names()
    {
        Assert.True(WinDefendHeadlineCopy.IsEngineProcess("MsMpEng"));
        Assert.True(WinDefendHeadlineCopy.IsEngineProcess("msmpeng"));
        Assert.False(WinDefendHeadlineCopy.IsEngineProcess("QuietGuard"));
        Assert.False(WinDefendHeadlineCopy.IsEngineProcess(null));
        Assert.Equal(WinDefendCopy.IsEngineProcess("MsMpEng"), WinDefendHeadlineCopy.IsEngineProcess("MsMpEng"));
        Assert.Equal(WinDefendNames.IsEngineProcess("MsMpEng"), WinDefendHeadlineCopy.IsEngineProcess("MsMpEng"));
    }

    [Fact]
    public void IsCommandLine_matches_copy_and_names()
    {
        const string full = @"C:\Program Files\Windows Defender\MpCmdRun.exe";
        Assert.True(WinDefendHeadlineCopy.IsCommandLine(full));
        Assert.True(WinDefendHeadlineCopy.IsCommandLine("MpCmdRun.exe"));
        Assert.False(WinDefendHeadlineCopy.IsCommandLine("powershell.exe"));
        Assert.Equal(WinDefendCopy.IsCommandLine(full), WinDefendHeadlineCopy.IsCommandLine(full));
        Assert.Equal(WinDefendNames.IsCommandLine(full), WinDefendHeadlineCopy.IsCommandLine(full));
    }
}
