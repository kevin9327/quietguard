using QuietGuard;

namespace QuietGuard.Tests;

public class ScanKindLabelsTests
{
    [Fact]
    public void Name_maps_quick_to_korean_label()
    {
        Assert.Equal("빠른 검사", ScanKindLabels.Name(ScanKind.Quick));
    }

    [Fact]
    public void Name_maps_full_to_korean_label()
    {
        Assert.Equal("전체 검사", ScanKindLabels.Name(ScanKind.Full));
    }

    [Fact]
    public void Name_maps_custom_file_to_korean_label()
    {
        Assert.Equal("파일 검사", ScanKindLabels.Name(ScanKind.CustomFile));
    }

    [Fact]
    public void Name_falls_back_to_ToString_for_undefined_kind()
    {
        var undefined = (ScanKind)999;

        Assert.Equal(undefined.ToString(), ScanKindLabels.Name(undefined));
    }
}
