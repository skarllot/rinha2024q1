using Rinha.MMXXIV.Q1.Contracts.Clientes.v1.ObterExtrato;

namespace Rinha.MMXXIV.Q1.Infrastructure.Clientes.v1.ObterExtrato;

public sealed record ExtratoModel(
    Guid Id,
    ObterExtratoResponse Data);
