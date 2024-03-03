using CSharpFunctionalExtensions;
using Rinha.MMXXIV.Q1.Contracts.Clientes.v1;
using Rinha.MMXXIV.Q1.Contracts.Clientes.v1.Transferir;
using Rinha.MMXXIV.Q1.Core.Clientes.Creditar;
using Rinha.MMXXIV.Q1.Core.Clientes.Debitar;
using Rinha.MMXXIV.Q1.Core.Common;

namespace Rinha.MMXXIV.Q1.Core.Clientes.Transferir.v1;

[GenerateAutomaticInterface]
public class ReceberTransferirParaCliente : IReceberTransferirParaCliente
{
    public Result<TransferirParaClienteResponse, ErroAoTransferir> Executar(
        IEventStore<Cliente> eventStore,
        TransferirParaClienteRequest request)
    {
        if (eventStore.Aggregate is null)
            return ErroAoTransferir.ClienteNaoEncontrado;

        return request.Tipo switch
        {
            TipoTransferência.Crédito => AcaoCreditarCliente
                .Executar(eventStore.Aggregate, new CreditarCliente(eventStore.Aggregate.Id, request.Valor, request.Descricao))
                .Tap(e => eventStore.AppendOne(e))
                .Map(e => eventStore.Aggregate.Apply(e))
                .Convert(
                    c => new TransferirParaClienteResponse(c.Limite, c.Saldo),
                    e => e switch
                    {
                        ErroCrédito.ValorNegativo => ErroAoTransferir.ValorNegativo,
                        ErroCrédito.ValorZerado => ErroAoTransferir.ValorZerado,
                        ErroCrédito.DescriçãoVazia => ErroAoTransferir.DescriçãoVazia,
                        ErroCrédito.DescriçãoMuitoLonga => ErroAoTransferir.DescriçãoMuitoLonga,
                        _ => ErroAoTransferir.ErroDesconhecido
                    }),

            TipoTransferência.Débito => AcaoDebitarCliente
                .Executar(eventStore.Aggregate, new DebitarCliente(eventStore.Aggregate.Id, request.Valor, request.Descricao))
                .Tap(e => eventStore.AppendOne(e))
                .Map(e => eventStore.Aggregate.Apply(e))
                .Convert(
                    c => new TransferirParaClienteResponse(c.Limite, c.Saldo),
                    e => e switch
                    {
                        ErroDébito.ValorNegativo => ErroAoTransferir.ValorNegativo,
                        ErroDébito.ValorZerado => ErroAoTransferir.ValorZerado,
                        ErroDébito.DescriçãoVazia => ErroAoTransferir.DescriçãoVazia,
                        ErroDébito.DescriçãoMuitoLonga => ErroAoTransferir.DescriçãoMuitoLonga,
                        ErroDébito.SaldoInsuficiente => ErroAoTransferir.SaldoInsuficiente,
                        ErroDébito.LimiteInsuficiente => ErroAoTransferir.LimiteInsuficiente,
                        _ => ErroAoTransferir.ErroDesconhecido
                    }),

            _ => ErroAoTransferir.TipoTransferênciaInválido
        };
    }
}
