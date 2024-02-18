using System.Buffers.Binary;

namespace Rinha.MMXXIV.Q1.Core.Common;

public static class IntAsGuidConverter
{
    public static Guid AsCombGuid(this long value)
    {
        Span<byte> guidBytes = stackalloc byte[16];
        guidBytes.Clear();
        BinaryPrimitives.WriteInt64BigEndian(guidBytes, value);
        SwapByteOrderForStringOrder(guidBytes);

        return new Guid(guidBytes);
    }

    public static long ToInt64(this Guid value)
    {
        Span<byte> guidBytes = stackalloc byte[16];
        value.TryWriteBytes(guidBytes);
        SwapByteOrderForStringOrder(guidBytes);

        return guidBytes[8..].Count((byte)0) == 8
            ? BinaryPrimitives.ReadInt64BigEndian(guidBytes)
            : 0;
    }

    private static void SwapByteOrderForStringOrder(Span<byte> input)
    {
        input[..4].Reverse();
        input.Slice(4, 2).Reverse();
    }
}
