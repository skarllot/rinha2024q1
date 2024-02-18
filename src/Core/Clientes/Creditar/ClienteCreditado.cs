namespace Rinha.MMXXIV.Q1.Core.Clientes.Creditar;

public sealed record ClienteCreditado(
    Guid Id,
    int Valor,
    string Descrição);
