using CSharpFunctionalExtensions;

namespace Rinha.MMXXIV.Q1.Core.Clientes.Debitar;

public static class AcaoDebitarCliente
{
    public static Result<ClienteDebitado, ErroDébito> Executar(
        Cliente cliente,
        DebitarCliente comando)
    {
        return comando switch
        {
            _ when comando.Valor < 0 => ErroDébito.ValorNegativo,
            _ when comando.Valor == 0 => ErroDébito.ValorZerado,
            _ when string.IsNullOrWhiteSpace(comando.Descrição) => ErroDébito.DescriçãoVazia,
            _ when comando.Descrição.Length > 10 => ErroDébito.DescriçãoMuitoLonga,
            _ when cliente.Limite == 0 && cliente.Saldo - comando.Valor < 0 => ErroDébito.SaldoInsuficiente,
            _ when cliente.Saldo + cliente.Limite - comando.Valor < 0 => ErroDébito.LimiteInsuficiente,

            _ => new ClienteDebitado(comando.Id, comando.Valor, comando.Descrição)
        };
    }
}
