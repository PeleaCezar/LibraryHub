namespace LibraryHub.Models.Editions;

public class MonthlyEdition : IEdition
{
    public int Month { get; private set; }
    public int Year { get; private set; }

    public MonthlyEdition(int month, int year) =>
        (Month, Year) = (
            month >= 1 && month <= 12 ? month : throw new ArgumentOutOfRangeException(nameof(Month)), year);

    public IEdition AdvanceToNext() =>
        new MonthlyEdition(Month % 12 + 1, Year + Month / 12);
}
