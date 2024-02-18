namespace Rinha.MMXXIV.Q1.Core.Clientes.Debitar;

public enum ErroDébito
{
    ValorNegativo = 1,
    ValorZerado,
    DescriçãoVazia,
    DescriçãoMuitoLonga,
    SaldoInsuficiente,
    LimiteInsuficiente
}
