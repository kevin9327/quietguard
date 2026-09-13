using QuietGuard;

namespace QuietGuard.Tests;

public class ThreatButtonStackTests
{
    [Fact]
    public void Labels_are_the_three_shipped_buttons_in_preferred_order()
    {
        IReadOnlyList<string> expected =
        [
            RestoreCopy.Button(),
            AllowCopy.Button(),
            RemediateCopy.Button()
        ];
        var fromPreferred = ThreatActionOrder.Preferred
            .Select(kind => kind switch
            {
                ThreatActionKind.Restore => RestoreCopy.Button(),
                ThreatActionKind.Allow => AllowCopy.Button(),
                ThreatActionKind.Remediate => RemediateCopy.Button(),
                _ => throw new ArgumentOutOfRangeException(nameof(kind), kind, null)
            })
            .ToArray();

        var labels = ThreatButtonStack.Labels();

        Assert.Equal(3, labels.Count);
        Assert.Equal(expected, labels);
        Assert.Equal(fromPreferred, labels);
    }

    [Fact]
    public void Labels_lead_with_restore()
    {
        Assert.Equal("복원", ThreatButtonStack.Labels()[0]);
    }
}
