using System.Collections.Immutable;

namespace Rinha.MMXXIV.Q1.Contracts.Clientes.v1.ObterExtrato;

public sealed record ObterExtratoResponse(
    Saldo Saldo,
    ImmutableList<Transação> UltimasTransacoes);
