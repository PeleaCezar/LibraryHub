namespace LibraryHub.Models.Editions;

public class OrdinalEdition(int number) : IEdition
{
    public int Number { get; private set; } =
        number > 0 ? number : throw new ArgumentOutOfRangeException(nameof(Number));

    public IEdition AdvanceToNext() =>
        new OrdinalEdition(Number + 1); 
}
