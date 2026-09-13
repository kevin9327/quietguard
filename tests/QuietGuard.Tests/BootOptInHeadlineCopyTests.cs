using QuietGuard;

namespace QuietGuard.Tests;

public class BootOptInHeadlineCopyTests
{
    [Fact]
    public void Checkbox_equals_boot_opt_in_copy()
    {
        Assert.Equal("시작 시 실행", BootOptInHeadlineCopy.Checkbox());
        Assert.Equal(BootOptInCopy.Checkbox(), BootOptInHeadlineCopy.Checkbox());
        Assert.Equal(BootStartCopy.Checkbox(), BootOptInHeadlineCopy.Checkbox());
    }

    [Fact]
    public void Enabled_follows_opt_in_not_protection_level()
    {
        Assert.True(BootOptInHeadlineCopy.Enabled(true, ProtectionLevel.Unprotected));
        Assert.False(BootOptInHeadlineCopy.Enabled(false, ProtectionLevel.Protected));
        Assert.Equal(
            BootOptInCopy.Enabled(true, ProtectionLevel.Unprotected),
            BootOptInHeadlineCopy.Enabled(true, ProtectionLevel.Unprotected));
        Assert.Equal(
            StartupRegistration.ShouldEnableAtBoot(true, ProtectionLevel.Unprotected),
            BootOptInHeadlineCopy.Enabled(true, ProtectionLevel.Unprotected));
    }
}
