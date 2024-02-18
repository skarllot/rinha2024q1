using Marten;
using Rinha.MMXXIV.Q1.Core.Common;

namespace Rinha.MMXXIV.Q1.Infrastructure;

public class MartenEntityStore<TEntity>(IDocumentSession session) : IEntityStore<TEntity>
    where TEntity : class
{
    public Task<TEntity?> Aggregate(Guid id, long version = 0, CancellationToken cancellationToken = default) =>
        session.Events.AggregateStreamAsync<TEntity>(id, version, token: cancellationToken);

    public void Append<TEvent>(Guid id, long version, TEvent entityEvent) where TEvent : class =>
        session.Events.Append(id, version, [entityEvent]);

    public Task SaveChanges(CancellationToken cancellationToken = default) =>
        session.SaveChangesAsync(cancellationToken);
}
