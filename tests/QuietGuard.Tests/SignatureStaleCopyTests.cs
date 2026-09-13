using QuietGuard;

namespace QuietGuard.Tests;

public class SignatureStaleCopyTests
{
    [Fact]
    public void Two_hours_is_within_range()
    {
        var age = TimeSpan.FromHours(2);

        Assert.False(SignatureStaleCopy.IsStale(age));
        Assert.Equal(
            SignatureAgeAdvisor.IsStale(age, ProtectionAdvisor.SignatureStaleAfter),
            SignatureStaleCopy.IsStale(age));
        Assert.Equal("정의 나이가 허용 범위입니다", SignatureStaleCopy.Headline(age));
    }

    [Fact]
    public void Eight_days_is_stale()
    {
        var age = TimeSpan.FromDays(8);

        Assert.True(SignatureStaleCopy.IsStale(age));
        Assert.Contains(SignatureAgeAdvisor.FormatAge(age), SignatureStaleCopy.Headline(age));
    }

    [Fact]
    public void Null_age_is_not_stale()
    {
        Assert.False(SignatureStaleCopy.IsStale(null));
    }
}
