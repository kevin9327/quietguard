using QuietGuard;

namespace QuietGuard.Tests;

public class StaleAfterCopyTests
{
    [Fact]
    public void Days_equals_3_days_and_ProtectionAdvisor_and_ProtectionCopy()
    {
        Assert.Equal(TimeSpan.FromDays(3), StaleAfterCopy.Days);
        Assert.Equal(ProtectionAdvisor.SignatureStaleAfter, StaleAfterCopy.Days);
        Assert.Equal(ProtectionCopy.SignatureStaleAfter, StaleAfterCopy.Days);
    }

    [Fact]
    public void AdvisorLimit_equals_Days_and_SignatureAgeAdvisor_and_SignatureAgeCopy()
    {
        Assert.Equal(StaleAfterCopy.Days, StaleAfterCopy.AdvisorLimit);
        Assert.Equal(SignatureAgeAdvisor.DefaultLimit, StaleAfterCopy.AdvisorLimit);
        Assert.Equal(SignatureAgeCopy.DefaultLimit, StaleAfterCopy.AdvisorLimit);
    }
}
