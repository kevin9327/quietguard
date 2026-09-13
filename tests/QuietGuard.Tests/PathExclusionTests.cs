using QuietGuard;

namespace QuietGuard.Tests;

public class PathExclusionTests
{
    [Fact]
    public void IsExcluded_downloads_setup_exe_not_excluded_by_empty_list()
    {
        Assert.False(PathExclusion.IsExcluded(@"C:\Users\a\Downloads\setup.exe", []));
    }

    [Fact]
    public void IsExcluded_downloads_setup_exe_excluded_by_parent_downloads_folder()
    {
        Assert.True(PathExclusion.IsExcluded(
            @"C:\Users\a\Downloads\setup.exe",
            [@"C:\Users\a\Downloads"]));
    }

    [Fact]
    public void IsExcluded_windows_notepad_excluded_by_default_quiet_exclusions()
    {
        Assert.True(PathExclusion.IsExcluded(
            @"C:\Windows\notepad.exe",
            PathExclusion.DefaultQuietExclusions()));
    }

    [Fact]
    public void IsExcluded_null_path_is_false()
    {
        Assert.False(PathExclusion.IsExcluded(null!, []));
    }
}
