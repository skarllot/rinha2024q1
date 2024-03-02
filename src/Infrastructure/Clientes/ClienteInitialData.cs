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

        StartStream(session, new ClienteCadastrado(PostgreSqlCombProvider.Create(1L), 100000, 0));
        StartStream(session, new ClienteCadastrado(PostgreSqlCombProvider.Create(2L), 80000, 0));
        StartStream(session, new ClienteCadastrado(PostgreSqlCombProvider.Create(3L), 1000000, 0));
        StartStream(session, new ClienteCadastrado(PostgreSqlCombProvider.Create(4L), 10000000, 0));
        StartStream(session, new ClienteCadastrado(PostgreSqlCombProvider.Create(5L), 500000, 0));

        await session.SaveChangesAsync(cancellation).ConfigureAwait(false);
        return;

        static void StartStream(IDocumentSession session, ClienteCadastrado evt) =>
            session.Events.StartStream<Cliente>(evt.Id, [evt]);
    }
}
