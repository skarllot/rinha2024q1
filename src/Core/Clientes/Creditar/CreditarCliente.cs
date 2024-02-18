namespace Rinha.MMXXIV.Q1.Core.Clientes.Creditar;

public sealed record CreditarCliente(
    Guid Id,
    int Valor,
    string Descrição);
