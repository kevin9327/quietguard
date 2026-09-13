using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatButtonCopyTests
{
    [Fact]
    public void Labels_equal_stack_restore_allow_remediate()
    {
        IReadOnlyList<string> expected =
        [
            RestoreCopy.Button(),
            AllowCopy.Button(),
            RemediateCopy.Button()
        ];
        Assert.Equal(expected, ThreatButtonCopy.Labels());
        Assert.Equal(ThreatButtonStack.Labels(), ThreatButtonCopy.Labels());
        Assert.Equal(3, ThreatButtonCopy.Labels().Count);
    }

    [Fact]
    public void Labels_contain_korean_restore_allow_remediate()
    {
        var labels = ThreatButtonCopy.Labels();
        Assert.Contains("복원", labels);
        Assert.Contains("허용", labels);
        Assert.Contains("치료 검사", labels);
    }
}
