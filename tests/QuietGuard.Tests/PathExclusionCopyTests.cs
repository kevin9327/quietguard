using QuietGuard;

namespace QuietGuard.Tests;

public class PathExclusionCopyTests
{
    [Fact]
    public void IsExcluded_downloads_setup_exe_not_excluded_by_empty_list()
    {
        var path = @"C:\Users\a\Downloads\setup.exe";
        string[] exclusions = [];

        Assert.False(PathExclusionCopy.IsExcluded(path, exclusions));
        Assert.Equal(PathExclusion.IsExcluded(path, exclusions), PathExclusionCopy.IsExcluded(path, exclusions));
    }

    [Fact]
    public void IsExcluded_downloads_setup_exe_excluded_by_parent_downloads_folder()
    {
        var path = @"C:\Users\a\Downloads\setup.exe";
        string[] exclusions = [@"C:\Users\a\Downloads"];

        Assert.True(PathExclusionCopy.IsExcluded(path, exclusions));
        Assert.Equal(PathExclusion.IsExcluded(path, exclusions), PathExclusionCopy.IsExcluded(path, exclusions));
    }

    [Fact]
    public void IsExcluded_windows_notepad_excluded_by_default_quiet_exclusions()
    {
        var path = @"C:\Windows\notepad.exe";
        var defaults = PathExclusion.DefaultQuietExclusions();

        Assert.True(PathExclusionCopy.IsExcluded(path, defaults));
        Assert.Equal(PathExclusion.IsExcluded(path, defaults), PathExclusionCopy.IsExcluded(path, defaults));
        Assert.True(PathExclusionCopy.IsQuietDefault(path));
        Assert.Equal(PathExclusion.IsExcluded(path, defaults), PathExclusionCopy.IsQuietDefault(path));
    }

    [Fact]
    public void IsExcluded_null_path_is_false()
    {
        Assert.False(PathExclusionCopy.IsExcluded(null!, []));
        Assert.Equal(PathExclusion.IsExcluded(null!, []), PathExclusionCopy.IsExcluded(null!, []));
    }

    [Fact]
    public void Defaults_sequence_equals_DefaultQuietExclusions()
    {
        Assert.Equal(PathExclusion.DefaultQuietExclusions(), PathExclusionCopy.Defaults());
    }
}
