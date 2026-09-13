using QuietGuard;

namespace QuietGuard.Tests;

public class SignatureAgeCopyTests
{
    [Fact]
    public void Default_limit_matches_ProtectionAdvisor_and_advisor()
    {
        Assert.Equal(ProtectionAdvisor.SignatureStaleAfter, SignatureAgeCopy.DefaultLimit);
        Assert.Equal(SignatureAgeAdvisor.DefaultLimit, SignatureAgeCopy.DefaultLimit);
    }

    [Fact]
    public void FormatAge_null_is_missing_timestamp()
    {
        Assert.Equal("정의 시각 없음", SignatureAgeCopy.FormatAge(null));
        Assert.Equal(SignatureAgeAdvisor.FormatAge(null), SignatureAgeCopy.FormatAge(null));
    }

    [Fact]
    public void FormatAge_20_minutes_is_minutes_ago()
    {
        var age = TimeSpan.FromMinutes(20);

        Assert.Equal("20분 전", SignatureAgeCopy.FormatAge(age));
        Assert.Equal(SignatureAgeAdvisor.FormatAge(age), SignatureAgeCopy.FormatAge(age));
    }

    [Fact]
    public void FormatAge_5_hours_is_hours_ago()
    {
        var age = TimeSpan.FromHours(5);

        Assert.Equal("5시간 전", SignatureAgeCopy.FormatAge(age));
        Assert.Equal(SignatureAgeAdvisor.FormatAge(age), SignatureAgeCopy.FormatAge(age));
    }

    [Fact]
    public void FormatAge_8_days_is_days_ago()
    {
        var age = TimeSpan.FromDays(8);

        Assert.Equal("8일 전", SignatureAgeCopy.FormatAge(age));
        Assert.Equal(SignatureAgeAdvisor.FormatAge(age), SignatureAgeCopy.FormatAge(age));
    }
}
