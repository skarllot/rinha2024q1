namespace Rinha.MMXXIV.Q1.Contracts.Clientes.v1.ObterExtrato;

public sealed record Transação(
    int Valor,
    TipoTransferência Tipo,
    string Descricao,
    DateTimeOffset RealizadaEm);
