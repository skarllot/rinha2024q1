namespace Rinha.MMXXIV.Q1.Contracts.Clientes.v1.Transferir;

public enum ErroAoTransferir
{
    ClienteNaoEncontrado = 1,
    TipoTransferênciaInválido,
    ValorNegativo,
    ValorZerado,
    DescriçãoVazia,
    DescriçãoMuitoLonga,
    SaldoInsuficiente,
    LimiteInsuficiente,
    ErroDesconhecido,
}
