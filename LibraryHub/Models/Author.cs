using System.Globalization;

namespace LibraryHub.Models;

/// <summary>
/// This separation of concerns results into responsability segregation
/// with each responsability of the author implemented in this class
/// </summary>

public class Author
{
    private string _fullName = string.Empty;

    public string FullName
    {
        get => _fullName;
        set => _fullName = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentNullException(nameof(value));
    }
     
    public CultureInfo Culture { get; set; }

    public Author(string fullName, CultureInfo culture) =>
        (Culture, FullName) = (culture, fullName);

    public void ToUppercase()
    {
        FullName = Culture.TextInfo.ToUpper(FullName);
    }

    public bool isMatch(string name) =>
        string.Compare(FullName, name, Culture, CompareOptions.IgnoreCase) == 0;
}
