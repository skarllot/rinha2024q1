namespace Rinha.MMXXIV.Q1.Contracts.Clientes.v1.Transferir;

public sealed record TransferirParaClienteRequest(
    int Valor,
    TipoTransferência Tipo,
    string Descricao);
