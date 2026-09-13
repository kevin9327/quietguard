using QuietGuard;

namespace QuietGuard.Tests;

public class DefinitionNotifyCopyTests
{
    [Fact]
    public void Stale_age_without_flag_is_quiet()
    {
        var age = TimeSpan.FromDays(8);

        Assert.False(DefinitionNotifyCopy.ShouldNotify(false, age));
        Assert.Equal(
            DefinitionUpdateAdvisor.ShouldNotifyAboutUpdate(false, age),
            DefinitionNotifyCopy.ShouldNotify(false, age));
    }

    [Fact]
    public void Stale_age_with_out_of_date_flag_notifies()
    {
        var age = TimeSpan.FromDays(8);

        Assert.True(DefinitionNotifyCopy.ShouldNotify(true, age));
    }

    [Fact]
    public void Fresh_age_without_flag_does_not_notify()
    {
        var age = TimeSpan.FromHours(1);

        Assert.False(DefinitionNotifyCopy.ShouldNotify(false, age));
    }

    [Fact]
    public void Arguments_match_definition_update_advisor()
    {
        Assert.Equal("-SignatureUpdate", DefinitionNotifyCopy.Arguments());
        Assert.Equal(DefinitionUpdateAdvisor.MpCmdArguments(), DefinitionNotifyCopy.Arguments());
    }
}
