using CSharpFunctionalExtensions;

namespace Rinha.MMXXIV.Q1.Core.Clientes.Creditar;

public static class AcaoCreditarCliente
{
    public static Result<ClienteCreditado, ErroCrédito> Executar(
        Cliente cliente,
        CreditarCliente comando)
    {
        return comando switch
        {
            _ when comando.Valor < 0 => ErroCrédito.ValorNegativo,
            _ when comando.Valor == 0 => ErroCrédito.ValorZerado,
            _ when string.IsNullOrWhiteSpace(comando.Descrição) => ErroCrédito.DescriçãoVazia,
            _ when comando.Descrição.Length > 10 => ErroCrédito.DescriçãoMuitoLonga,

            _ => new ClienteCreditado(comando.Id, comando.Valor, comando.Descrição)
        };
    }
}
