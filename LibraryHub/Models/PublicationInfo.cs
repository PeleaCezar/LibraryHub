namespace LibraryHub.Models;

public abstract record PublicationInfo
{
    public abstract bool isPublishedBefore(DateOnly date);
    public abstract bool IsPlannedBefore(DateOnly date);
}

public sealed record Published(PublicationDate PublishedOn) : PublicationInfo
{
    public override bool isPublishedBefore(DateOnly date) => PublishedOn.EndsBefore(date);
    public override bool IsPlannedBefore(DateOnly date) => PublishedOn.EndsBefore(date);
}

public sealed record Planned(PublicationDate PlannedFor) : PublicationInfo
{
    public override bool isPublishedBefore(DateOnly date) => false;
    public override bool IsPlannedBefore(DateOnly date) => PlannedFor.EndsBefore(date);
}

public sealed record NotPlannedYet : PublicationInfo
{
    public override bool isPublishedBefore(DateOnly date) => false;
    public override bool IsPlannedBefore(DateOnly date) => false;
}
