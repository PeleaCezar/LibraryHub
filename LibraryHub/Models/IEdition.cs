namespace LibraryHub.Models;

public interface IEdition{ }

public record OrdinalEdition(int Number) : IEdition;

public class SeasonalEdition : IEdition
{
    public enum YearSeason { Spring, Summer, Autumn, Winter };

    public YearSeason Season { get; set; }

    public int Year { get; set; }

    public SeasonalEdition(YearSeason season, int year) =>
        (Season, Year) = (season, year);
}