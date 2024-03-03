using System.Diagnostics.CodeAnalysis;
using Marten;
using Marten.Events;
using Rinha.MMXXIV.Q1.Core.Common;

namespace Rinha.MMXXIV.Q1.Infrastructure;

[SuppressMessage("Design", "CA1000:Do not declare static members on generic types")]
public static class MartenEventStore2<TAggregate> where TAggregate : class
{
    public static async Task<TResponse> WriteToAggregate<TRequest, TResponse>(
        IDocumentSession session,
        Guid id,
        TRequest request,
        Func<IEventStore<TAggregate>, TRequest, TResponse> handler,
        CancellationToken cancellationToken)
    {
        var eventStream = await session.Events
            .FetchForExclusiveWriting<TAggregate>(id, cancellationToken)
            .ConfigureAwait(false);

        var wrapper = new MartenEventStore<TAggregate>(eventStream);
        TResponse result = handler(wrapper, request);

        await session.SaveChangesAsync(cancellationToken);

        return result;
    }
}

public class MartenEventStore<TAggregate>(IEventStream<TAggregate> eventStream) : IEventStore<TAggregate>
    where TAggregate : class
{
    public TAggregate? Aggregate => eventStream.Aggregate;

    public void AppendOne<TEvent>(TEvent newEvent) where TEvent : class => eventStream.AppendOne(newEvent);
}
