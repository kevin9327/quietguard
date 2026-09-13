using QuietGuard;

namespace QuietGuard.Tests;

public class SignatureUpdateCopyTests
{
    [Fact]
    public void Button_matches_tray_menu_label()
    {
        Assert.Equal(TrayMenuLabels.UpdateDefinitions, SignatureUpdateCopy.Button());
        Assert.Equal("정의 업데이트", SignatureUpdateCopy.Button());
    }

    [Fact]
    public void Arguments_match_definition_update_advisor()
    {
        Assert.Equal(DefinitionUpdateAdvisor.MpCmdArguments(), SignatureUpdateCopy.Arguments());
        Assert.Contains("-SignatureUpdate", SignatureUpdateCopy.Arguments());
    }
}
