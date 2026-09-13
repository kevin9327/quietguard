using QuietGuard;

namespace QuietGuard.Tests;

public class DisclaimerHeadlineCopyTests
{
    [Fact]
    public void Text_equals_footer_copy_and_product_disclaimer()
    {
        Assert.Equal(DisclaimerFooterCopy.Text(), DisclaimerHeadlineCopy.Text());
        Assert.Equal(ProductDisclaimer.Footer(), DisclaimerHeadlineCopy.Text());
        Assert.Contains("Microsoft Defender", DisclaimerHeadlineCopy.Text());
        Assert.Contains("AhnLab V3 코드나 이름을 사용하지 않습니다.", DisclaimerHeadlineCopy.Text());
    }

    [Fact]
    public void MentionsDefender_is_true()
    {
        Assert.True(DisclaimerHeadlineCopy.MentionsDefender());
        Assert.Equal(DisclaimerFooterCopy.MentionsDefender(), DisclaimerHeadlineCopy.MentionsDefender());
    }

    [Fact]
    public void RejectsV3_is_true()
    {
        Assert.True(DisclaimerHeadlineCopy.RejectsV3());
        Assert.Equal(DisclaimerFooterCopy.RejectsV3(), DisclaimerHeadlineCopy.RejectsV3());
    }
}
