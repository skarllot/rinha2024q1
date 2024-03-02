// <auto-generated/>
#pragma warning disable
using Marten;
using Marten.Events.Aggregation;
using Marten.Internal.Storage;
using System;
using System.Linq;

namespace Marten.Generated.EventStore
{
    // START: SingleStreamProjectionLiveAggregation1137135420
    public class SingleStreamProjectionLiveAggregation1137135420 : Marten.Events.Aggregation.SyncLiveAggregatorBase<Rinha.MMXXIV.Q1.Core.Clientes.Cliente>
    {
        private readonly Marten.Events.Aggregation.SingleStreamProjection<Rinha.MMXXIV.Q1.Core.Clientes.Cliente> _singleStreamProjection;

        public SingleStreamProjectionLiveAggregation1137135420(Marten.Events.Aggregation.SingleStreamProjection<Rinha.MMXXIV.Q1.Core.Clientes.Cliente> singleStreamProjection)
        {
            _singleStreamProjection = singleStreamProjection;
        }



        public override Rinha.MMXXIV.Q1.Core.Clientes.Cliente Build(System.Collections.Generic.IReadOnlyList<Marten.Events.IEvent> events, Marten.IQuerySession session, Rinha.MMXXIV.Q1.Core.Clientes.Cliente snapshot)
        {
            if (!events.Any()) return null;
            Rinha.MMXXIV.Q1.Core.Clientes.Cliente cliente = null;
            var usedEventOnCreate = snapshot is null;
            snapshot ??= Create(events[0], session);;
            if (snapshot is null)
            {
                usedEventOnCreate = false;
                snapshot = CreateDefault(events[0]);
            }

            foreach (var @event in events.Skip(usedEventOnCreate ? 1 : 0))
            {
                snapshot = Apply(@event, snapshot, session);
            }

            return snapshot;
        }


        public Rinha.MMXXIV.Q1.Core.Clientes.Cliente Create(Marten.Events.IEvent @event, Marten.IQuerySession session)
        {
            switch (@event)
            {
                case Marten.Events.IEvent<Rinha.MMXXIV.Q1.Core.Clientes.Cadastrar.ClienteCadastrado> event_ClienteCadastrado1:
                    return Rinha.MMXXIV.Q1.Core.Clientes.Cliente.Create(event_ClienteCadastrado1.Data);
                    break;
            }

            return null;
        }


        public Rinha.MMXXIV.Q1.Core.Clientes.Cliente CreateDefault(Marten.Events.IEvent @event)
        {
            throw new System.InvalidOperationException($"There is no default constructor for Rinha.MMXXIV.Q1.Core.Clientes.Cliente or Create method for {@event.DotNetTypeName} event type.Check more about the create method convention in documentation: https://martendb.io/events/projections/event-projections.html#create-method-convention. If you're using Upcasting, check if {@event.DotNetTypeName} is an old event type. If it is, make sure to define transformation for it to new event type. Read more in Upcasting docs: https://martendb.io/events/versioning.html#upcasting-advanced-payload-transformations.");
        }


        public Rinha.MMXXIV.Q1.Core.Clientes.Cliente Apply(Marten.Events.IEvent @event, Rinha.MMXXIV.Q1.Core.Clientes.Cliente aggregate, Marten.IQuerySession session)
        {
            switch (@event)
            {
                case Marten.Events.IEvent<Rinha.MMXXIV.Q1.Core.Clientes.Creditar.ClienteCreditado> event_ClienteCreditado2:
                    aggregate = aggregate.Apply(event_ClienteCreditado2.Data);
                    break;
                case Marten.Events.IEvent<Rinha.MMXXIV.Q1.Core.Clientes.Debitar.ClienteDebitado> event_ClienteDebitado3:
                    aggregate = aggregate.Apply(event_ClienteDebitado3.Data);
                    break;
            }

            return aggregate;
        }

    }

    // END: SingleStreamProjectionLiveAggregation1137135420
    
    
    // START: SingleStreamProjectionInlineHandler1137135420
    public class SingleStreamProjectionInlineHandler1137135420 : Marten.Events.Aggregation.AggregationRuntime<Rinha.MMXXIV.Q1.Core.Clientes.Cliente, System.Guid>
    {
        private readonly Marten.IDocumentStore _store;
        private readonly Marten.Events.Aggregation.IAggregateProjection _projection;
        private readonly Marten.Events.Aggregation.IEventSlicer<Rinha.MMXXIV.Q1.Core.Clientes.Cliente, System.Guid> _slicer;
        private readonly Marten.Internal.Storage.IDocumentStorage<Rinha.MMXXIV.Q1.Core.Clientes.Cliente, System.Guid> _storage;
        private readonly Marten.Events.Aggregation.SingleStreamProjection<Rinha.MMXXIV.Q1.Core.Clientes.Cliente> _singleStreamProjection;

        public SingleStreamProjectionInlineHandler1137135420(Marten.IDocumentStore store, Marten.Events.Aggregation.IAggregateProjection projection, Marten.Events.Aggregation.IEventSlicer<Rinha.MMXXIV.Q1.Core.Clientes.Cliente, System.Guid> slicer, Marten.Internal.Storage.IDocumentStorage<Rinha.MMXXIV.Q1.Core.Clientes.Cliente, System.Guid> storage, Marten.Events.Aggregation.SingleStreamProjection<Rinha.MMXXIV.Q1.Core.Clientes.Cliente> singleStreamProjection) : base(store, projection, slicer, storage)
        {
            _store = store;
            _projection = projection;
            _slicer = slicer;
            _storage = storage;
            _singleStreamProjection = singleStreamProjection;
        }



        public override async System.Threading.Tasks.ValueTask<Rinha.MMXXIV.Q1.Core.Clientes.Cliente> ApplyEvent(Marten.IQuerySession session, Marten.Events.Projections.EventSlice<Rinha.MMXXIV.Q1.Core.Clientes.Cliente, System.Guid> slice, Marten.Events.IEvent evt, Rinha.MMXXIV.Q1.Core.Clientes.Cliente aggregate, System.Threading.CancellationToken cancellationToken)
        {
            switch (evt)
            {
                case Marten.Events.IEvent<Rinha.MMXXIV.Q1.Core.Clientes.Cadastrar.ClienteCadastrado> event_ClienteCadastrado7:
                    aggregate = Rinha.MMXXIV.Q1.Core.Clientes.Cliente.Create(event_ClienteCadastrado7.Data);
                    return aggregate;
                case Marten.Events.IEvent<Rinha.MMXXIV.Q1.Core.Clientes.Creditar.ClienteCreditado> event_ClienteCreditado5:
                    if(aggregate == default) throw new Marten.Exceptions.InvalidProjectionException("Projection for Rinha.MMXXIV.Q1.Core.Clientes.Cliente should either have a static Create method that returns the event type Marten.Events.IEvent<Rinha.MMXXIV.Q1.Core.Clientes.Creditar.ClienteCreditado> or Rinha.MMXXIV.Q1.Core.Clientes.Cliente should have either have a public, no argument constructor or a constructor function that takes the Marten.Events.IEvent<Rinha.MMXXIV.Q1.Core.Clientes.Creditar.ClienteCreditado> as a parameter. This error occurs when Marten is trying to build a new aggregate, but the aggregate projection does not have a way to create a new aggregate from the first event in the event stream. A common cause is persisting events out of order according to your application's domain logic rules");
                    aggregate = aggregate.Apply(event_ClienteCreditado5.Data);
                    return aggregate;
                case Marten.Events.IEvent<Rinha.MMXXIV.Q1.Core.Clientes.Debitar.ClienteDebitado> event_ClienteDebitado6:
                    if(aggregate == default) throw new Marten.Exceptions.InvalidProjectionException("Projection for Rinha.MMXXIV.Q1.Core.Clientes.Cliente should either have a static Create method that returns the event type Marten.Events.IEvent<Rinha.MMXXIV.Q1.Core.Clientes.Debitar.ClienteDebitado> or Rinha.MMXXIV.Q1.Core.Clientes.Cliente should have either have a public, no argument constructor or a constructor function that takes the Marten.Events.IEvent<Rinha.MMXXIV.Q1.Core.Clientes.Debitar.ClienteDebitado> as a parameter. This error occurs when Marten is trying to build a new aggregate, but the aggregate projection does not have a way to create a new aggregate from the first event in the event stream. A common cause is persisting events out of order according to your application's domain logic rules");
                    aggregate = aggregate.Apply(event_ClienteDebitado6.Data);
                    return aggregate;
            }

            return aggregate;
        }


        public Rinha.MMXXIV.Q1.Core.Clientes.Cliente Create(Marten.Events.IEvent @event, Marten.IQuerySession session)
        {
            switch (@event)
            {
                case Marten.Events.IEvent<Rinha.MMXXIV.Q1.Core.Clientes.Cadastrar.ClienteCadastrado> event_ClienteCadastrado4:
                    return Rinha.MMXXIV.Q1.Core.Clientes.Cliente.Create(event_ClienteCadastrado4.Data);
                    break;
            }

            return null;
        }


        public Rinha.MMXXIV.Q1.Core.Clientes.Cliente CreateDefault(Marten.Events.IEvent @event)
        {
            throw new System.InvalidOperationException($"There is no default constructor for Rinha.MMXXIV.Q1.Core.Clientes.Cliente or Create method for {@event.DotNetTypeName} event type.Check more about the create method convention in documentation: https://martendb.io/events/projections/event-projections.html#create-method-convention. If you're using Upcasting, check if {@event.DotNetTypeName} is an old event type. If it is, make sure to define transformation for it to new event type. Read more in Upcasting docs: https://martendb.io/events/versioning.html#upcasting-advanced-payload-transformations.");
        }

    }

    // END: SingleStreamProjectionInlineHandler1137135420
    
    
}
