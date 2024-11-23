using LibraryHub.Common;

namespace LibraryHub.Models.Editions;

public class SeasonalEdition : IEdition
{
    public YearSeason Season { get; private set; }

    public int Year { get; private set; }

    public SeasonalEdition(YearSeason season, int year) =>
        (Season, Year) = (season, year);

    public IEdition AdvanceToNext() =>
        new SeasonalEdition(Season.Next(), Season.IsLast() ? Year + 1 : Year);
}
