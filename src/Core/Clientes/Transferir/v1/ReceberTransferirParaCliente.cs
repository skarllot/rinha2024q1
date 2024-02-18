using CSharpFunctionalExtensions;
using Rinha.MMXXIV.Q1.Contracts.Clientes.v1;
using Rinha.MMXXIV.Q1.Contracts.Clientes.v1.Transferir;
using Rinha.MMXXIV.Q1.Core.Clientes.Creditar;
using Rinha.MMXXIV.Q1.Core.Clientes.Debitar;
using Rinha.MMXXIV.Q1.Core.Common;

namespace Rinha.MMXXIV.Q1.Core.Clientes.Transferir.v1;

[GenerateAutomaticInterface]
public class ReceberTransferirParaCliente(IEntityStore<Cliente> entityStore) : IReceberTransferirParaCliente
{
    public async Task<Result<TransferirParaClienteResponse, ErroAoTransferir>> Executar(
        long id,
        TransferirParaClienteRequest request,
        CancellationToken cancellationToken)
    {
        var dbId = id.AsCombGuid();
        var cliente = await entityStore.Aggregate(dbId, cancellationToken);
        if (cliente is null)
            return ErroAoTransferir.ClienteNaoEncontrado;

        return request.Tipo switch
        {
            TipoTransferência.Crédito => await AcaoCreditarCliente
                .Executar(cliente, new CreditarCliente(dbId, request.Valor, request.Descricao))
                .Tap(e => entityStore.AppendAndSaveChanges(e.Id, cliente.Version, e, cancellationToken))
                .Convert(
                    _ => new TransferirParaClienteResponse(cliente.Limite, cliente.Saldo),
                    e => e switch
                    {
                        ErroCrédito.ValorNegativo => ErroAoTransferir.ValorNegativo,
                        ErroCrédito.ValorZerado => ErroAoTransferir.ValorZerado,
                        ErroCrédito.DescriçãoVazia => ErroAoTransferir.DescriçãoVazia,
                        ErroCrédito.DescriçãoMuitoLonga => ErroAoTransferir.DescriçãoMuitoLonga,
                        _ => ErroAoTransferir.ErroDesconhecido
                    }),

            TipoTransferência.Débito => await AcaoDebitarCliente
                .Executar(cliente, new DebitarCliente(dbId, request.Valor, request.Descricao))
                .Tap(e => entityStore.AppendAndSaveChanges(e.Id, cliente.Version, e, cancellationToken))
                .Convert(
                    _ => new TransferirParaClienteResponse(cliente.Limite, cliente.Saldo),
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
