namespace Rinha.MMXXIV.Q1.Core.Clientes.Debitar;

public sealed record DebitarCliente(
    Guid Id,
    int Valor,
    string Descrição);
