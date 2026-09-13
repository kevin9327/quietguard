using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatLabelHeadlineCopyTests
{
    [Fact]
    public void Button_maps_restore_to_korean_label()
    {
        Assert.Equal("복원", ThreatLabelHeadlineCopy.Button(ThreatActionKind.Restore));
        Assert.Equal(ThreatLabelCopy.Button(ThreatActionKind.Restore), ThreatLabelHeadlineCopy.Button(ThreatActionKind.Restore));
        Assert.Equal(ThreatActionLabels.Button(ThreatActionKind.Restore), ThreatLabelHeadlineCopy.Button(ThreatActionKind.Restore));
    }

    [Fact]
    public void Button_maps_allow_to_korean_label()
    {
        Assert.Equal("허용", ThreatLabelHeadlineCopy.Button(ThreatActionKind.Allow));
        Assert.Equal(ThreatLabelCopy.Button(ThreatActionKind.Allow), ThreatLabelHeadlineCopy.Button(ThreatActionKind.Allow));
        Assert.Equal(ThreatActionLabels.Button(ThreatActionKind.Allow), ThreatLabelHeadlineCopy.Button(ThreatActionKind.Allow));
    }

    [Fact]
    public void Button_maps_remediate_to_korean_label()
    {
        Assert.Equal("치료 검사", ThreatLabelHeadlineCopy.Button(ThreatActionKind.Remediate));
        Assert.Equal(ThreatLabelCopy.Button(ThreatActionKind.Remediate), ThreatLabelHeadlineCopy.Button(ThreatActionKind.Remediate));
        Assert.Equal(ThreatActionLabels.Button(ThreatActionKind.Remediate), ThreatLabelHeadlineCopy.Button(ThreatActionKind.Remediate));
    }

    [Fact]
    public void Restore_matches_ThreatLabelCopy_and_ThreatActionLabels()
    {
        Assert.Equal("복원", ThreatLabelHeadlineCopy.Restore());
        Assert.Equal(ThreatLabelCopy.Restore(), ThreatLabelHeadlineCopy.Restore());
        Assert.Equal(ThreatActionLabels.Button(ThreatActionKind.Restore), ThreatLabelHeadlineCopy.Restore());
    }

    [Fact]
    public void Allow_matches_ThreatLabelCopy_and_ThreatActionLabels()
    {
        Assert.Equal("허용", ThreatLabelHeadlineCopy.Allow());
        Assert.Equal(ThreatLabelCopy.Allow(), ThreatLabelHeadlineCopy.Allow());
        Assert.Equal(ThreatActionLabels.Button(ThreatActionKind.Allow), ThreatLabelHeadlineCopy.Allow());
    }

    [Fact]
    public void Remediate_matches_ThreatLabelCopy_and_ThreatActionLabels()
    {
        Assert.Equal("치료 검사", ThreatLabelHeadlineCopy.Remediate());
        Assert.Equal(ThreatLabelCopy.Remediate(), ThreatLabelHeadlineCopy.Remediate());
        Assert.Equal(ThreatActionLabels.Button(ThreatActionKind.Remediate), ThreatLabelHeadlineCopy.Remediate());
    }

    [Fact]
    public void Button_falls_back_to_ToString_for_undefined_kind()
    {
        var undefined = (ThreatActionKind)999;

        Assert.Equal(undefined.ToString(), ThreatLabelHeadlineCopy.Button(undefined));
        Assert.Equal(ThreatLabelCopy.Button(undefined), ThreatLabelHeadlineCopy.Button(undefined));
        Assert.Equal(ThreatActionLabels.Button(undefined), ThreatLabelHeadlineCopy.Button(undefined));
    }
}
