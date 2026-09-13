using QuietGuard;

namespace QuietGuard.Tests;

public class UpdateNowCopyTests
{
    [Fact]
    public void Button_is_definition_update()
    {
        Assert.Equal("정의 업데이트", UpdateNowCopy.Button());
    }

    [Fact]
    public void Fresh_age_without_flag_is_current()
    {
        var age = TimeSpan.FromHours(2);

        Assert.False(DefinitionUpdateAdvisor.ShouldUpdate(false, age));
        Assert.Equal("정의가 최신입니다", UpdateNowCopy.Status(false, age));
    }

    [Fact]
    public void Stale_age_without_flag_is_quiet_status()
    {
        var age = TimeSpan.FromDays(8);

        Assert.True(DefinitionUpdateAdvisor.ShouldUpdate(false, age));
        Assert.False(DefinitionUpdateAdvisor.ShouldNotifyAboutUpdate(false, age));
        Assert.Equal(UpdateNowCopy.QuietStatus(), UpdateNowCopy.Status(false, age));
    }

    [Fact]
    public void Out_of_date_flag_is_alert_status()
    {
        var age = TimeSpan.FromHours(2);

        Assert.True(DefinitionUpdateAdvisor.ShouldUpdate(true, age));
        Assert.True(DefinitionUpdateAdvisor.ShouldNotifyAboutUpdate(true, age));
        Assert.Equal(UpdateNowCopy.AlertStatus(), UpdateNowCopy.Status(true, age));
    }
}
