namespace LibraryHub.Models;

// Separation of concerns
// With concerns separate this model can implement whatever behavior it's needed in future development
public abstract record PublicationDate
{
    public abstract bool EndsBefore(DateOnly date);
}

public sealed record FullDate(DateOnly Date) : PublicationDate
{
    public override bool EndsBefore(DateOnly date) => Date < date;
}

public sealed record YearMonth(int Year, int Month) : PublicationDate
{
    public override bool EndsBefore(DateOnly date) => Year < date.Year || (Year == date.Year && Month < date.Month);
}

public sealed record Year(int Number) : PublicationDate
{
    public override bool EndsBefore(DateOnly date) => Number < date.Year;
}
