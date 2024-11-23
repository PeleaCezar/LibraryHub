using LibraryHub.Repositories;

namespace LibraryHub.Models;

/// <summary>
/// It's not the responsability of the Book class to know details about  creation of the Publisher entity
/// So, I put it in the new Publisher entity
/// </summary>
public class Book : IAggregateRoot
{
    public string _title = string.Empty;

    public string Title
    {
        get => _title;
        set => _title = !string.IsNullOrEmpty(value) ? value : throw new ArgumentNullException(nameof(Title));
    }

    public AuthorsList Authors { get; set; }

    public Release Release { get; set; }

    public Book(string title, AuthorsList authors, Release release) =>
        (Title, Authors, Release) = (title, authors, release);
}
