namespace Rinha.MMXXIV.Q1.Core.Common;

public interface IEntityStore<TEntity>
    where TEntity : class
{
    Task<TEntity?> Aggregate(Guid id, long version = 0, CancellationToken cancellationToken = default);

    Task<TEntity?> Aggregate(Guid id, CancellationToken cancellationToken = default) =>
        Aggregate(id, 0, cancellationToken);

    void Append<TEvent>(Guid id, long version, TEvent entityEvent) where TEvent : class;

    Task AppendAndSaveChanges<TEvent>(
        Guid id,
        long version,
        TEvent entityEvent,
        CancellationToken cancellationToken = default)
        where TEvent : class
    {
        Append(id, version, entityEvent);
        return SaveChanges(cancellationToken);
    }

    Task SaveChanges(CancellationToken cancellationToken = default);
}
