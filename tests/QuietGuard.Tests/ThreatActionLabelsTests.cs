using System.IO;
using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatActionLabelsTests
{
    [Fact]
    public void Button_maps_restore_to_korean_label()
    {
        Assert.Equal("복원", ThreatActionLabels.Button(ThreatActionKind.Restore));
    }

    [Fact]
    public void Button_maps_allow_to_korean_label()
    {
        Assert.Equal("허용", ThreatActionLabels.Button(ThreatActionKind.Allow));
    }

    [Fact]
    public void Button_maps_remediate_to_korean_label()
    {
        Assert.Equal("치료 검사", ThreatActionLabels.Button(ThreatActionKind.Remediate));
    }

    [Fact]
    public void Button_falls_back_to_ToString_for_undefined_kind()
    {
        var undefined = (ThreatActionKind)999;

        Assert.Equal(undefined.ToString(), ThreatActionLabels.Button(undefined));
    }

    [Fact]
    public void MainWindow_buttons_use_named_controls_not_hardcoded_captions()
    {
        var xaml = ReadRepoFile(Path.Combine("src", "QuietGuard.App", "MainWindow.xaml"));
        var cs = ReadRepoFile(Path.Combine("src", "QuietGuard.App", "MainWindow.xaml.cs"));

        Assert.Contains("x:Name=\"RestoreButton\"", xaml);
        Assert.Contains("x:Name=\"AllowButton\"", xaml);
        Assert.Contains("x:Name=\"RemediateButton\"", xaml);
        Assert.DoesNotContain("Content=\"복원\"", xaml);
        Assert.DoesNotContain("Content=\"허용\"", xaml);
        Assert.DoesNotContain("Content=\"치료 검사\"", xaml);
        Assert.Contains("ThreatActionLabels.Button(ThreatActionKind.Restore)", cs);
        Assert.Contains("ThreatActionLabels.Button(ThreatActionKind.Allow)", cs);
        Assert.Contains("ThreatActionLabels.Button(ThreatActionKind.Remediate)", cs);
        Assert.Equal("복원", ThreatActionLabels.Button(ThreatActionKind.Restore));
        Assert.Equal("허용", ThreatActionLabels.Button(ThreatActionKind.Allow));
        Assert.Equal("치료 검사", ThreatActionLabels.Button(ThreatActionKind.Remediate));
    }

    private static string ReadRepoFile(string relative)
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir is not null)
        {
            var candidate = Path.Combine(dir.FullName, relative);
            if (File.Exists(candidate))
                return File.ReadAllText(candidate);
            dir = dir.Parent;
        }

        throw new FileNotFoundException(relative);
    }
}
