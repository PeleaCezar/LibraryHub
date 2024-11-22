using System.Collections;
using System.Globalization;
using LibraryHub.Common;

namespace LibraryHub.Models;

/// <summary>
/// Writing intention-revealing code is useful to prevent expain these methods do
/// </summary>
public class AuthorsList : IEnumerable<Author>
{
    private List<Author> AuthorsCollection { get; set; }

    public IEnumerable<CultureInfo> Cultures  =>
        AuthorsCollection.Select(author => author.Culture).Distinct();

    public AuthorsList(IEnumerable<Author> authors) =>
       AuthorsCollection = authors.ToList();

    public void AppendAuthor(Author author)
    {
        AuthorsCollection.Add(author);
    }

    public bool RemoveAuthor(string name) =>
        AuthorsCollection.Remove(FilterByName(name));

    private Func<Author, bool> FilterByName(string name) =>
        author => author.isMatch(name);

    public void AuthorsToUppercase() =>
        AuthorsCollection.ForEach(author => author.ToUppercase());
    
    public bool MoveAuthorUp(string name) =>
        AuthorsCollection.SwapWithPrevious(FilterByName(name));

    public bool MoveAuthorDown(string name) =>
        AuthorsCollection.SwapWithNext(FilterByName(name));

    public bool MoveAuthorToBeginning(string name) =>
        AuthorsCollection.MoveToBeginning(FilterByName(name));

    public bool MoveAuthorToEnd(string name) =>
        AuthorsCollection.MoveToEnd(FilterByName(name));

    public IEnumerator<Author> GetEnumerator() => AuthorsCollection.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
