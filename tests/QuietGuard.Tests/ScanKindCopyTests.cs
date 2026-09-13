using QuietGuard;

namespace QuietGuard.Tests;

public class ScanKindCopyTests
{
    [Fact]
    public void Name_maps_quick_to_korean_label()
    {
        Assert.Equal("빠른 검사", ScanKindCopy.Name(ScanKind.Quick));
        Assert.Equal(ScanKindLabels.Name(ScanKind.Quick), ScanKindCopy.Name(ScanKind.Quick));
    }

    [Fact]
    public void Name_maps_full_to_korean_label()
    {
        Assert.Equal("전체 검사", ScanKindCopy.Name(ScanKind.Full));
        Assert.Equal(ScanKindLabels.Name(ScanKind.Full), ScanKindCopy.Name(ScanKind.Full));
    }

    [Fact]
    public void Name_maps_custom_file_to_korean_label()
    {
        Assert.Equal("파일 검사", ScanKindCopy.Name(ScanKind.CustomFile));
        Assert.Equal(ScanKindLabels.Name(ScanKind.CustomFile), ScanKindCopy.Name(ScanKind.CustomFile));
    }

    [Fact]
    public void Quick_matches_ScanKindLabels_quick()
    {
        Assert.Equal("빠른 검사", ScanKindCopy.Quick());
        Assert.Equal(ScanKindLabels.Name(ScanKind.Quick), ScanKindCopy.Quick());
    }

    [Fact]
    public void Full_matches_ScanKindLabels_full()
    {
        Assert.Equal("전체 검사", ScanKindCopy.Full());
        Assert.Equal(ScanKindLabels.Name(ScanKind.Full), ScanKindCopy.Full());
    }

    [Fact]
    public void CustomFile_matches_ScanKindLabels_custom_file()
    {
        Assert.Equal("파일 검사", ScanKindCopy.CustomFile());
        Assert.Equal(ScanKindLabels.Name(ScanKind.CustomFile), ScanKindCopy.CustomFile());
    }

    [Fact]
    public void Name_falls_back_to_ToString_for_undefined_kind()
    {
        var undefined = (ScanKind)999;

        Assert.Equal(undefined.ToString(), ScanKindCopy.Name(undefined));
        Assert.Equal(ScanKindLabels.Name(undefined), ScanKindCopy.Name(undefined));
    }
}
