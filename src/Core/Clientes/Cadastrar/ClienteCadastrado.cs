namespace Rinha.MMXXIV.Q1.Core.Clientes.Cadastrar;

public sealed record ClienteCadastrado(
    Guid Id,
    int Limite,
    int SaldoInicial);
