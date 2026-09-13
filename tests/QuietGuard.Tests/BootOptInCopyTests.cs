using QuietGuard;

namespace QuietGuard.Tests;

public class BootOptInCopyTests
{
    [Fact]
    public void Checkbox_equals_boot_start_copy()
    {
        Assert.Equal(BootStartCopy.Checkbox(), BootOptInCopy.Checkbox());
        Assert.Equal("시작 시 실행", BootOptInCopy.Checkbox());
    }

    [Fact]
    public void Enabled_true_protected_matches_registration()
    {
        const bool userOptIn = true;
        const ProtectionLevel level = ProtectionLevel.Protected;

        var enabled = BootOptInCopy.Enabled(userOptIn, level);

        Assert.Equal(StartupRegistration.ShouldEnableAtBoot(userOptIn, level), enabled);
        Assert.Equal(BootStartCopy.MatchesRegistration(userOptIn, level), enabled);
        Assert.True(enabled);
    }

    [Fact]
    public void Enabled_false_unprotected_is_false()
    {
        Assert.False(BootOptInCopy.Enabled(false, ProtectionLevel.Unprotected));
    }
}
