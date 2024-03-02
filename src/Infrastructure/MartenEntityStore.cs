using Marten;
using Rinha.MMXXIV.Q1.Core.Common;

namespace Rinha.MMXXIV.Q1.Infrastructure;

public class MartenEntityStore<TEntity>(IDocumentSession session) : IEntityStore<TEntity>
    where TEntity : class
{
    public Task<TEntity?> Aggregate(Guid id, long version = 0, CancellationToken cancellationToken = default) =>
        id != Guid.Empty
            ? session.Events.AggregateStreamAsync<TEntity>(id, version, token: cancellationToken)
            : Task.FromResult(default(TEntity));

    public void Append<TEvent>(Guid id, long version, TEvent entityEvent) where TEvent : class =>
        session.Events.Append(id, version + 1L, [entityEvent]);

    public Task SaveChanges(CancellationToken cancellationToken = default) =>
        session.SaveChangesAsync(cancellationToken);
}
