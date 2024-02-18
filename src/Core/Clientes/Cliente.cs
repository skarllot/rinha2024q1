using Rinha.MMXXIV.Q1.Core.Clientes.Cadastrar;

namespace Rinha.MMXXIV.Q1.Core.Clientes;

public record Cliente(
    Guid Id,
    int Limite,
    int Saldo)
{
    public static Cliente Create(ClienteCadastrado cadastrado) =>
        new(cadastrado.Id, cadastrado.Limite, cadastrado.SaldoInicial);
}
