namespace Rinha.MMXXIV.Q1.Core.Common;

public interface IEventStore<TAggregate> where TAggregate : class
{
    TAggregate? Aggregate { get; }

    void AppendOne<TEvent>(TEvent newEvent) where TEvent : class;
}
