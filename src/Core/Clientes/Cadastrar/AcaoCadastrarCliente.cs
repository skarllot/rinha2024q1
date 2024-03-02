using CSharpFunctionalExtensions;
using Rinha.MMXXIV.Q1.Core.Common;

namespace Rinha.MMXXIV.Q1.Core.Clientes.Cadastrar;

public static class AcaoCadastrarCliente
{
    public static Result<ClienteCadastrado, ErroCadastro> Executar(CadastrarCliente comando)
    {
        return comando switch
        {
            _ when PostgreSqlCombProvider.GetSequence(comando.Id) <= 0 => ErroCadastro.IdInvalido,
            _ when comando.Limite < 0 => ErroCadastro.LimiteInvalido,
            _ when comando.SaldoInicial < 0 => ErroCadastro.SaldoInicialInvalido,

            _ => new ClienteCadastrado(
                comando.Id,
                comando.Limite,
                comando.SaldoInicial)
        };
    }
}
