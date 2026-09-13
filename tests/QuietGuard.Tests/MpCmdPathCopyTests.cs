using QuietGuard;

namespace QuietGuard.Tests;

public class MpCmdPathCopyTests
{
    [Fact]
    public void Resolve_equals_engine_and_exists()
    {
        var path = MpCmdPathCopy.Resolve();
        Assert.Equal(DefenderEngine.ResolveMpCmdRun(), path);
        Assert.True(File.Exists(path));
        Assert.Equal("MpCmdRun.exe", Path.GetFileName(path));
        Assert.True(MpCmdPathCopy.IsCommandLine(path));
        Assert.Equal(WinDefendNames.IsCommandLine(path), MpCmdPathCopy.IsCommandLine(path));
    }

    [Fact]
    public void IsCommandLine_rejects_powershell()
    {
        Assert.False(MpCmdPathCopy.IsCommandLine("powershell.exe"));
        Assert.Equal(WinDefendNames.IsCommandLine("powershell.exe"), MpCmdPathCopy.IsCommandLine("powershell.exe"));
    }
}
