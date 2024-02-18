using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rinha.MMXXIV.Q1.Contracts.Clientes.v1.Transferir;

[JsonConverter(typeof(TipoTransferênciaJsonConverter))]
public enum TipoTransferência
{
    Crédito = 1,
    Débito
}

public sealed class TipoTransferênciaJsonConverter : JsonConverter<TipoTransferência>
{
    private const int MaxValueLength = 1;

    public override TipoTransferência Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        int length = reader.HasValueSequence ? checked((int)reader.ValueSequence.Length) : reader.ValueSpan.Length;
        if (length != MaxValueLength)
            return 0;

        Span<char> letter = stackalloc char[MaxValueLength];
        reader.CopyString(letter);
        return letter switch
        {
            "c" => TipoTransferência.Crédito,
            "d" => TipoTransferência.Débito,
            _ => 0
        };
    }

    public override void Write(Utf8JsonWriter writer, TipoTransferência value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case TipoTransferência.Crédito:
                writer.WriteStringValue("c"u8);
                break;
            case TipoTransferência.Débito:
                writer.WriteStringValue("d"u8);
                break;
            default:
                writer.WriteNullValue();
                break;
        }
    }
}
