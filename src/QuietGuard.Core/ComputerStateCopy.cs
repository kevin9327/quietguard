namespace QuietGuard;

public static class ComputerStateCopy
{
    public static string Headline(string? productStatus) => ComputerStateText.Describe(productStatus);

    public static string Headline(DefenderStatus status) => ComputerStateText.Describe(status);
}
