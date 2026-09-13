using QuietGuard;

namespace QuietGuard.Tests;

public class SignatureAgeAdvisorTests
{
    [Fact]
    public void Null_age_is_not_stale()
    {
        Assert.False(SignatureAgeAdvisor.IsStale(null));
    }

    [Fact]
    public void Age_inside_limit_is_not_stale()
    {
        Assert.False(SignatureAgeAdvisor.IsStale(TimeSpan.FromHours(12), TimeSpan.FromDays(3)));
    }

    [Fact]
    public void Age_past_limit_is_stale()
    {
        Assert.True(SignatureAgeAdvisor.IsStale(TimeSpan.FromDays(8), TimeSpan.FromDays(3)));
        Assert.True(SignatureAgeAdvisor.IsStale(TimeSpan.FromDays(8)));
    }

    [Fact]
    public void Default_limit_matches_ProtectionAdvisor()
    {
        Assert.Equal(ProtectionAdvisor.SignatureStaleAfter, SignatureAgeAdvisor.DefaultLimit);
    }

    [Fact]
    public void FormatAge_uses_minutes_hours_days()
    {
        Assert.Equal("정의 시각 없음", SignatureAgeAdvisor.FormatAge(null));
        Assert.Equal("정의 시각 없음", SignatureAgeAdvisor.FormatAge(TimeSpan.FromMinutes(-1)));
        Assert.Equal("20분 전", SignatureAgeAdvisor.FormatAge(TimeSpan.FromMinutes(20)));
        Assert.Equal("5시간 전", SignatureAgeAdvisor.FormatAge(TimeSpan.FromHours(5)));
        Assert.Equal("8일 전", SignatureAgeAdvisor.FormatAge(TimeSpan.FromDays(8)));
    }
}
