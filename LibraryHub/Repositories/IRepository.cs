namespace LibraryHub.Repositories;

/// <summary>
/// In DDD repositories can only return aggregates, each aggregate type has precisely one entity designated as its root
/// For example, asking releases from a repository of book it's not correct because a release only exists within a book
/// So, it's correctly to load books from db, but it's wrong to load book releases alone
/// to enforce our generic repository to load only aggregate roots, we will use IAggregateRoot within our aggregates roots(principal entities)
/// and also as a constraint in the generic repository
/// </summary>

interface IRepository<T> where T : IAggregateRoot
{
    IEnumerable<T> GetAll();
}

class GenericRepository<T>(IEnumerable<T> data) : IRepository<T> where T : IAggregateRoot
{
    public IEnumerable<T> GetAll() => data;
}

interface IAggregateRoot;
