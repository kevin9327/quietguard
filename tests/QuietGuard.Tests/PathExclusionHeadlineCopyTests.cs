using QuietGuard;

namespace QuietGuard.Tests;

public class PathExclusionHeadlineCopyTests
{
    [Fact]
    public void IsExcluded_downloads_setup_exe_not_excluded_by_empty_list()
    {
        var path = @"C:\Users\a\Downloads\setup.exe";
        string[] exclusions = [];

        Assert.False(PathExclusionHeadlineCopy.IsExcluded(path, exclusions));
        Assert.Equal(PathExclusionCopy.IsExcluded(path, exclusions), PathExclusionHeadlineCopy.IsExcluded(path, exclusions));
        Assert.Equal(PathExclusion.IsExcluded(path, exclusions), PathExclusionHeadlineCopy.IsExcluded(path, exclusions));
    }

    [Fact]
    public void IsExcluded_windows_notepad_excluded_by_defaults()
    {
        var path = @"C:\Windows\notepad.exe";
        var defaults = PathExclusionHeadlineCopy.Defaults();

        Assert.True(PathExclusionHeadlineCopy.IsExcluded(path, defaults));
        Assert.Equal(PathExclusionCopy.IsExcluded(path, defaults), PathExclusionHeadlineCopy.IsExcluded(path, defaults));
        Assert.Equal(PathExclusion.IsExcluded(path, defaults), PathExclusionHeadlineCopy.IsExcluded(path, defaults));
        Assert.True(PathExclusionHeadlineCopy.IsQuietDefault(path));
        Assert.Equal(PathExclusionCopy.IsQuietDefault(path), PathExclusionHeadlineCopy.IsQuietDefault(path));
        Assert.Equal(
            PathExclusion.IsExcluded(path, PathExclusion.DefaultQuietExclusions()),
            PathExclusionHeadlineCopy.IsQuietDefault(path));
        Assert.Equal(PathExclusionCopy.Defaults(), PathExclusionHeadlineCopy.Defaults());
        Assert.Equal(PathExclusion.DefaultQuietExclusions(), PathExclusionHeadlineCopy.Defaults());
    }
}
