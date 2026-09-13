using QuietGuard;

namespace QuietGuard.Tests;

public class DisclaimerFooterCopyTests
{
    [Fact]
    public void Text_equals_ProductDisclaimer_Footer()
    {
        Assert.Equal(ProductDisclaimer.Footer(), DisclaimerFooterCopy.Text());
    }

    [Fact]
    public void MentionsDefender_is_true()
    {
        Assert.True(DisclaimerFooterCopy.MentionsDefender());
    }

    [Fact]
    public void RejectsV3_is_true()
    {
        Assert.True(DisclaimerFooterCopy.RejectsV3());
    }

    [Fact]
    public void Text_contains_no_ads()
    {
        Assert.Contains("광고 없음", DisclaimerFooterCopy.Text());
    }
}
