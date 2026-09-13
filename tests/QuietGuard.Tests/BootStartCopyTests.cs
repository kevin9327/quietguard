using QuietGuard;

namespace QuietGuard.Tests;

public class BootStartCopyTests
{
    [Fact]
    public void Checkbox_is_run_at_startup()
    {
        Assert.Equal("시작 시 실행", BootStartCopy.Checkbox());
    }

    [Theory]
    [InlineData(true, ProtectionLevel.Protected)]
    [InlineData(false, ProtectionLevel.Protected)]
    [InlineData(true, ProtectionLevel.Unprotected)]
    [InlineData(false, ProtectionLevel.Unprotected)]
    public void MatchesRegistration_follows_user_opt_in(
        bool userOptIn,
        ProtectionLevel level)
    {
        Assert.Equal(userOptIn, StartupRegistration.ShouldEnableAtBoot(userOptIn, level));
        Assert.True(BootStartCopy.MatchesRegistration(userOptIn, level));
    }
}
