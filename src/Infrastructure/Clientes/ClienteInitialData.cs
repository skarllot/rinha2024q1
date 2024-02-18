using Marten;
using Marten.Schema;
using Rinha.MMXXIV.Q1.Core.Clientes;
using Rinha.MMXXIV.Q1.Core.Clientes.Cadastrar;
using Rinha.MMXXIV.Q1.Core.Common;

namespace Rinha.MMXXIV.Q1.Infrastructure.Clientes;

public class ClienteInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        await using var session = store.LightweightSession();

        if (await session.Events.QueryAllRawEvents().AnyAsync(cancellation))
        {
            return;
        }

        session.Events.StartStream<Cliente>(1L.AsCombGuid(), [new ClienteCadastrado(1L.AsCombGuid(), 100000, 0)]);
        session.Events.StartStream<Cliente>(2L.AsCombGuid(), [new ClienteCadastrado(2L.AsCombGuid(), 80000, 0)]);
        session.Events.StartStream<Cliente>(3L.AsCombGuid(), [new ClienteCadastrado(3L.AsCombGuid(), 1000000, 0)]);
        session.Events.StartStream<Cliente>(4L.AsCombGuid(), [new ClienteCadastrado(4L.AsCombGuid(), 10000000, 0)]);
        session.Events.StartStream<Cliente>(5L.AsCombGuid(), [new ClienteCadastrado(5L.AsCombGuid(), 500000, 0)]);

        await session.SaveChangesAsync(cancellation).ConfigureAwait(false);
    }
}
