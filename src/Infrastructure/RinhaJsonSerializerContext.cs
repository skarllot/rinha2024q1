using System.Text.Json.Serialization;
using Rinha.MMXXIV.Q1.Contracts.Clientes.v1.ObterExtrato;
using Rinha.MMXXIV.Q1.Contracts.Clientes.v1.Transferir;

namespace Rinha.MMXXIV.Q1.Infrastructure;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower)]
[JsonSerializable(typeof(TransferirParaClienteRequest))]
[JsonSerializable(typeof(TransferirParaClienteResponse))]
[JsonSerializable(typeof(ObterExtratoResponse))]
public partial class RinhaJsonSerializerContext : JsonSerializerContext;
