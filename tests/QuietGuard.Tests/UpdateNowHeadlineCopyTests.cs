using QuietGuard;

namespace QuietGuard.Tests;

public class UpdateNowHeadlineCopyTests
{
    [Fact]
    public void Button_is_definition_update()
    {
        Assert.Equal("정의 업데이트", UpdateNowHeadlineCopy.Button());
        Assert.Equal(UpdateNowCopy.Button(), UpdateNowHeadlineCopy.Button());
    }

    [Fact]
    public void Fresh_age_without_flag_is_current()
    {
        var age = TimeSpan.FromHours(2);

        Assert.False(DefinitionUpdateAdvisor.ShouldUpdate(false, age));
        Assert.Equal("정의가 최신입니다", UpdateNowHeadlineCopy.Status(false, age));
        Assert.Equal(UpdateNowCopy.Status(false, age), UpdateNowHeadlineCopy.Status(false, age));
    }

    [Fact]
    public void Stale_age_without_flag_is_quiet_status()
    {
        var age = TimeSpan.FromDays(8);

        Assert.True(DefinitionUpdateAdvisor.ShouldUpdate(false, age));
        Assert.False(DefinitionUpdateAdvisor.ShouldNotifyAboutUpdate(false, age));
        Assert.Equal(UpdateNowHeadlineCopy.QuietStatus(), UpdateNowHeadlineCopy.Status(false, age));
        Assert.Equal(UpdateNowCopy.QuietStatus(), UpdateNowHeadlineCopy.QuietStatus());
        Assert.Equal(UpdateNowCopy.Status(false, age), UpdateNowHeadlineCopy.Status(false, age));
    }

    [Fact]
    public void Out_of_date_flag_is_alert_status()
    {
        var age = TimeSpan.FromHours(2);

        Assert.True(DefinitionUpdateAdvisor.ShouldUpdate(true, age));
        Assert.True(DefinitionUpdateAdvisor.ShouldNotifyAboutUpdate(true, age));
        Assert.Equal(UpdateNowHeadlineCopy.AlertStatus(), UpdateNowHeadlineCopy.Status(true, age));
        Assert.Equal(UpdateNowCopy.AlertStatus(), UpdateNowHeadlineCopy.AlertStatus());
        Assert.Equal(UpdateNowCopy.Status(true, age), UpdateNowHeadlineCopy.Status(true, age));
    }
}
