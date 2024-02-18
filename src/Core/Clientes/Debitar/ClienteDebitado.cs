namespace Rinha.MMXXIV.Q1.Core.Clientes.Debitar;

public sealed record ClienteDebitado(
    Guid Id,
    int Valor,
    string Descrição);
