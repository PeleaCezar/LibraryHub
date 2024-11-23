using System.Globalization;

namespace LibraryHub.Models;
/// <summary>
/// Open closed principle was applied here because we can extend this class by writing new polymorphic implementations
/// of each type it depends on, not by changing this class here
/// </summary>
public class Release
{
    public Publisher Publisher { get; private set; }

    public IEdition Edition { get; private set; }

    public PublicationDate PublicationDate { get; private set; }

    public CultureInfo Culture { get; private set; }

    public Release(Publisher publisher, IEdition edition, PublicationDate publicationDate, CultureInfo culture) =>
    (Publisher, Edition, PublicationDate, Culture) = (publisher, edition, publicationDate, culture);

    public void AdvanceToNext(PublicationDate publicationDate)
    {
        PublicationDate = publicationDate;
        Edition = Edition.AdvanceToNext();
    }
}
