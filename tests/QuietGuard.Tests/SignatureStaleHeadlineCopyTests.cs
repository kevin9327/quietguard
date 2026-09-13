using QuietGuard;

namespace QuietGuard.Tests;

public class SignatureStaleHeadlineCopyTests
{
    [Fact]
    public void Two_hours_is_within_range()
    {
        var age = TimeSpan.FromHours(2);

        Assert.False(SignatureStaleHeadlineCopy.IsStale(age));
        Assert.Equal(SignatureStaleCopy.IsStale(age), SignatureStaleHeadlineCopy.IsStale(age));
        Assert.Equal(
            SignatureAgeAdvisor.IsStale(age, ProtectionAdvisor.SignatureStaleAfter),
            SignatureStaleHeadlineCopy.IsStale(age));
        Assert.Equal("정의 나이가 허용 범위입니다", SignatureStaleHeadlineCopy.Headline(age));
        Assert.Equal(SignatureStaleCopy.Headline(age), SignatureStaleHeadlineCopy.Headline(age));
    }

    [Fact]
    public void Eight_days_is_stale()
    {
        var age = TimeSpan.FromDays(8);

        Assert.True(SignatureStaleHeadlineCopy.IsStale(age));
        Assert.Equal(SignatureStaleCopy.IsStale(age), SignatureStaleHeadlineCopy.IsStale(age));
        Assert.Equal(
            SignatureAgeAdvisor.IsStale(age, ProtectionAdvisor.SignatureStaleAfter),
            SignatureStaleHeadlineCopy.IsStale(age));
        Assert.Contains(SignatureAgeAdvisor.FormatAge(age), SignatureStaleHeadlineCopy.Headline(age));
        Assert.Equal(SignatureStaleCopy.Headline(age), SignatureStaleHeadlineCopy.Headline(age));
    }

    [Fact]
    public void Null_age_is_not_stale()
    {
        Assert.False(SignatureStaleHeadlineCopy.IsStale(null));
        Assert.Equal(SignatureStaleCopy.IsStale(null), SignatureStaleHeadlineCopy.IsStale(null));
        Assert.Equal(SignatureAgeAdvisor.IsStale(null), SignatureStaleHeadlineCopy.IsStale(null));
        Assert.Equal("정의 나이가 허용 범위입니다", SignatureStaleHeadlineCopy.Headline(null));
        Assert.Equal(SignatureStaleCopy.Headline(null), SignatureStaleHeadlineCopy.Headline(null));
    }
}
