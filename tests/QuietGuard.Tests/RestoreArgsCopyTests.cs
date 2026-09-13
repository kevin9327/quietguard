using QuietGuard;

namespace QuietGuard.Tests;

public class RestoreArgsCopyTests
{
    [Fact]
    public void All_equals_restore_all_args_and_copy()
    {
        Assert.Equal("-Restore -All", RestoreArgsCopy.All());
        Assert.Equal(RestoreAllArgs.All(), RestoreArgsCopy.All());
        Assert.Equal(RestoreCopy.AllArguments(), RestoreArgsCopy.All());
    }

    [Fact]
    public void File_equals_restore_all_args_and_copy()
    {
        var path = @"C:\Users\a\Downloads\payload.exe";
        Assert.Equal(RestoreAllArgs.File(path), RestoreArgsCopy.File(path));
        Assert.Equal(RestoreCopy.FileArguments(path), RestoreArgsCopy.File(path));
        Assert.Contains($"\"{path}\"", RestoreArgsCopy.File(path));
    }

    [Fact]
    public void File_empty_throws()
    {
        Assert.Throws<ArgumentException>(() => RestoreArgsCopy.File(""));
    }
}
