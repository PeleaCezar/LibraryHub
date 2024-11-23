using LibraryHub.Models;
using LibraryHub.Models.Editions;

namespace LibraryHub.Common;

public static class EnumExtensions
{
    public static bool IsLast(this YearSeason value) =>
        value is YearSeason.Winter;

    public static YearSeason Next(this YearSeason yearSeason)
    {
        var yearSeasons = (YearSeason[])Enum.GetValues(typeof(YearSeason));

        int currentIndex = Array.IndexOf(yearSeasons, yearSeason);

        var nextIndex = (currentIndex + 1) % yearSeasons.Length;

        return yearSeasons[nextIndex];
    }
}
