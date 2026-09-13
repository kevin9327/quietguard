using QuietGuard;

namespace QuietGuard.Tests;

public class SignatureArgsCopyTests
{
    [Fact]
    public void Arguments_equals_signature_update_and_copies()
    {
        Assert.Equal("-SignatureUpdate", SignatureArgsCopy.Arguments());
        Assert.Equal(DefinitionUpdateAdvisor.MpCmdArguments(), SignatureArgsCopy.Arguments());
        Assert.Equal(SignatureUpdateCopy.Arguments(), SignatureArgsCopy.Arguments());
        Assert.Equal(DefinitionNotifyCopy.Arguments(), SignatureArgsCopy.Arguments());
    }

    [Fact]
    public void QuietRefreshAfter_equals_1_day_and_advisor()
    {
        Assert.Equal(TimeSpan.FromDays(1), SignatureArgsCopy.QuietRefreshAfter);
        Assert.Equal(DefinitionUpdateAdvisor.QuietRefreshAfter, SignatureArgsCopy.QuietRefreshAfter);
    }
}
