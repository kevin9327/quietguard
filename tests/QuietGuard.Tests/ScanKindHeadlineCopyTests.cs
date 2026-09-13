using QuietGuard;

namespace QuietGuard.Tests;

public class ScanKindHeadlineCopyTests
{
    [Fact]
    public void Name_maps_quick_to_korean_label()
    {
        Assert.Equal("빠른 검사", ScanKindHeadlineCopy.Name(ScanKind.Quick));
        Assert.Equal(ScanKindCopy.Name(ScanKind.Quick), ScanKindHeadlineCopy.Name(ScanKind.Quick));
        Assert.Equal(ScanKindLabels.Name(ScanKind.Quick), ScanKindHeadlineCopy.Name(ScanKind.Quick));
    }

    [Fact]
    public void Name_maps_full_to_korean_label()
    {
        Assert.Equal("전체 검사", ScanKindHeadlineCopy.Name(ScanKind.Full));
        Assert.Equal(ScanKindCopy.Name(ScanKind.Full), ScanKindHeadlineCopy.Name(ScanKind.Full));
        Assert.Equal(ScanKindLabels.Name(ScanKind.Full), ScanKindHeadlineCopy.Name(ScanKind.Full));
    }

    [Fact]
    public void Name_maps_custom_file_to_korean_label()
    {
        Assert.Equal("파일 검사", ScanKindHeadlineCopy.Name(ScanKind.CustomFile));
        Assert.Equal(ScanKindCopy.Name(ScanKind.CustomFile), ScanKindHeadlineCopy.Name(ScanKind.CustomFile));
        Assert.Equal(ScanKindLabels.Name(ScanKind.CustomFile), ScanKindHeadlineCopy.Name(ScanKind.CustomFile));
    }

    [Fact]
    public void Quick_matches_ScanKindCopy_and_ScanKindLabels()
    {
        Assert.Equal("빠른 검사", ScanKindHeadlineCopy.Quick());
        Assert.Equal(ScanKindCopy.Quick(), ScanKindHeadlineCopy.Quick());
        Assert.Equal(ScanKindLabels.Name(ScanKind.Quick), ScanKindHeadlineCopy.Quick());
    }

    [Fact]
    public void Full_matches_ScanKindCopy_and_ScanKindLabels()
    {
        Assert.Equal("전체 검사", ScanKindHeadlineCopy.Full());
        Assert.Equal(ScanKindCopy.Full(), ScanKindHeadlineCopy.Full());
        Assert.Equal(ScanKindLabels.Name(ScanKind.Full), ScanKindHeadlineCopy.Full());
    }

    [Fact]
    public void CustomFile_matches_ScanKindCopy_and_ScanKindLabels()
    {
        Assert.Equal("파일 검사", ScanKindHeadlineCopy.CustomFile());
        Assert.Equal(ScanKindCopy.CustomFile(), ScanKindHeadlineCopy.CustomFile());
        Assert.Equal(ScanKindLabels.Name(ScanKind.CustomFile), ScanKindHeadlineCopy.CustomFile());
    }

    [Fact]
    public void Name_falls_back_to_ToString_for_undefined_kind()
    {
        var undefined = (ScanKind)999;

        Assert.Equal(undefined.ToString(), ScanKindHeadlineCopy.Name(undefined));
        Assert.Equal(ScanKindCopy.Name(undefined), ScanKindHeadlineCopy.Name(undefined));
        Assert.Equal(ScanKindLabels.Name(undefined), ScanKindHeadlineCopy.Name(undefined));
    }
}
