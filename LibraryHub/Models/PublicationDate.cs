namespace LibraryHub.Models;

// Separation of concerns
// With concerns separate this model can implement whatever behavior it's needed in future development
public abstract record PublicationDate;

public sealed record FullDate(DateOnly Date);
public sealed record YearMonth(int Year, int Month);
public sealed record Year(int Number);
