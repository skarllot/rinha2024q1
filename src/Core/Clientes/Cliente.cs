using Rinha.MMXXIV.Q1.Core.Clientes.Cadastrar;
using Rinha.MMXXIV.Q1.Core.Clientes.Creditar;
using Rinha.MMXXIV.Q1.Core.Clientes.Debitar;

namespace Rinha.MMXXIV.Q1.Core.Clientes;

public record Cliente(
    Guid Id,
    int Limite,
    int Saldo)
{
    public long Version { get; private init; }

    public static Cliente Create(ClienteCadastrado cadastrado) =>
        new(cadastrado.Id, cadastrado.Limite, cadastrado.SaldoInicial) { Version = 1 };

    public Cliente Apply(ClienteCreditado creditado) =>
        this with { Saldo = Saldo + creditado.Valor, Version = Version + 1 };

    public Cliente Apply(ClienteDebitado debitado) =>
        this with { Saldo = Saldo - debitado.Valor, Version = Version + 1 };
}
