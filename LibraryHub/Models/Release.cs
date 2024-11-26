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

    public PublicationInfo Publication{ get; private set; }

    public CultureInfo Culture { get; private set; }

    public Release(Publisher publisher, IEdition edition, PublicationInfo publication, CultureInfo culture) =>
    (Publisher, Edition, Publication, Culture) = (publisher, edition, publication, culture);

    public void AdvanceToNext(PublicationInfo publication)
    {
        Publication = publication;
        Edition = Edition.AdvanceToNext();
    }

    public void SetStatus(PublicationInfo publication)
    {
        if (Publication is Published) return;
        Publication = publication;
    }
}

// New Requirement
// Some books may have not been published yet
// The date you see in the PublicationDate is only the planned date when the book will appear
// also, the planned publication date might be missing
// some unpublished books will have the planned date, while some others will only attain later