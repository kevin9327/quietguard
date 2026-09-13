using QuietGuard;

namespace QuietGuard.Tests;

public class TrayClampCopyTests
{
    [Fact]
    public void MaxLength_equals_63_and_tray_tooltip()
    {
        Assert.Equal(63, TrayClampCopy.MaxLength);
        Assert.Equal(TrayTooltip.MaxLength, TrayClampCopy.MaxLength);
    }

    [Fact]
    public void Clamp_null_or_empty_is_quietguard()
    {
        Assert.Equal("QuietGuard", TrayClampCopy.Clamp(null!));
        Assert.Equal(TrayTooltip.Clamp(null!), TrayClampCopy.Clamp(null!));
        Assert.Equal("QuietGuard", TrayClampCopy.Clamp(string.Empty));
        Assert.Equal(TrayTooltip.Clamp(string.Empty), TrayClampCopy.Clamp(string.Empty));
    }

    [Fact]
    public void Clamp_hi_is_hi()
    {
        Assert.Equal("hi", TrayClampCopy.Clamp("hi"));
    }

    [Fact]
    public void Clamp_80_a_length_is_63()
    {
        var text = new string('a', 80);
        Assert.Equal(63, TrayClampCopy.Clamp(text).Length);
        Assert.Equal(TrayTooltip.Clamp(text), TrayClampCopy.Clamp(text));
    }
}
