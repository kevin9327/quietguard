using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatEmptyCopyTests
{
    [Fact]
    public void Placeholder_equals_empty_list_placeholder()
    {
        Assert.Equal(ThreatListPresentation.EmptyListPlaceholder, ThreatEmptyCopy.Placeholder());
        Assert.Equal("최근 위협 없음", ThreatEmptyCopy.Placeholder());
    }

    [Fact]
    public void Headline_zero_equals_count_text_and_placeholder()
    {
        Assert.Equal(ThreatCountText.Format(0), ThreatEmptyCopy.Headline(0));
        Assert.Equal(ThreatEmptyCopy.Placeholder(), ThreatEmptyCopy.Headline(0));
    }

    [Fact]
    public void Headline_two_equals_count_text()
    {
        Assert.Equal(ThreatCountText.Format(2), ThreatEmptyCopy.Headline(2));
    }
}
