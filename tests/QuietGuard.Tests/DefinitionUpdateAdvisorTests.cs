using QuietGuard;

namespace QuietGuard.Tests;

public class DefinitionUpdateAdvisorTests
{
    [Fact]
    public void Fresh_age_without_flag_does_not_update_or_notify()
    {
        var age = TimeSpan.FromHours(2);

        Assert.False(SignatureAgeAdvisor.IsStale(age));
        Assert.False(DefinitionUpdateAdvisor.ShouldUpdate(false, age));
        Assert.False(DefinitionUpdateAdvisor.ShouldNotifyAboutUpdate(false, age));
    }

    [Fact]
    public void Stale_age_without_flag_updates_quietly()
    {
        var age = TimeSpan.FromDays(8);

        Assert.True(SignatureAgeAdvisor.IsStale(age));
        Assert.True(DefinitionUpdateAdvisor.ShouldUpdate(false, age));
        Assert.False(DefinitionUpdateAdvisor.ShouldNotifyAboutUpdate(false, age));
    }

    [Fact]
    public void Out_of_date_flag_updates_and_notifies_even_when_age_is_fresh()
    {
        var age = TimeSpan.FromHours(2);

        Assert.False(SignatureAgeAdvisor.IsStale(age));
        Assert.True(DefinitionUpdateAdvisor.ShouldUpdate(true, age));
        Assert.True(DefinitionUpdateAdvisor.ShouldNotifyAboutUpdate(true, age));
    }

    [Fact]
    public void MpCmdArguments_contains_SignatureUpdate()
    {
        Assert.Contains("-SignatureUpdate", DefinitionUpdateAdvisor.MpCmdArguments());
    }
}
