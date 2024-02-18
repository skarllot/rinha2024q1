namespace Rinha.MMXXIV.Q1.Contracts.Clientes.v1.ObterExtrato;

public sealed record Saldo(
    int Total,
    DateTimeOffset DataExtrato,
    int Limite);
