using System.Collections.Immutable;
using Marten.Events;
using Marten.Events.Aggregation;
using Rinha.MMXXIV.Q1.Contracts.Clientes.v1;
using Rinha.MMXXIV.Q1.Contracts.Clientes.v1.ObterExtrato;
using Rinha.MMXXIV.Q1.Core.Clientes.Cadastrar;
using Rinha.MMXXIV.Q1.Core.Clientes.Creditar;
using Rinha.MMXXIV.Q1.Core.Clientes.Debitar;

namespace Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato;

public class ObterExtratoProjection : SingleStreamProjection<ExtratoModel>
{
    private const int NumTransacoesExtrato = 10;

    public ObterExtratoProjection()
    {
        CreateEvent<IEvent<ClienteCadastrado>>(
            static e => new ExtratoModel(
                e.StreamId,
                new ObterExtratoResponse(
                    new Saldo(e.Data.SaldoInicial, e.Timestamp, e.Data.Limite),
                    ImmutableList<Transação>.Empty)));

        ProjectEvent<IEvent<ClienteCreditado>>(
            static (curr, e) => curr with
            {
                Data = new ObterExtratoResponse(
                    curr.Data.Saldo with { Total = curr.Data.Saldo.Total + e.Data.Valor, DataExtrato = e.Timestamp },
                    curr.Data.UltimasTransacoes
                        .Prepend(
                            new Transação(
                                e.Data.Valor,
                                TipoTransferência.Crédito,
                                e.Data.Descrição,
                                e.Timestamp))
                        .Take(NumTransacoesExtrato)
                        .ToImmutableList())
            });

        ProjectEvent<IEvent<ClienteDebitado>>(
            static (curr, e) => curr with
            {
                Data = new ObterExtratoResponse(
                    curr.Data.Saldo with { Total = curr.Data.Saldo.Total - e.Data.Valor, DataExtrato = e.Timestamp },
                    curr.Data.UltimasTransacoes
                        .Prepend(
                            new Transação(
                                e.Data.Valor,
                                TipoTransferência.Débito,
                                e.Data.Descrição,
                                e.Timestamp))
                        .Take(NumTransacoesExtrato)
                        .ToImmutableList())
            });
    }
}
