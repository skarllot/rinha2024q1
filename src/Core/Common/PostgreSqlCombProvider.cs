using System.Buffers.Binary;

namespace Rinha.MMXXIV.Q1.Core.Common;

public static class PostgreSqlCombProvider
{
    public static Guid Create(long seq)
    {
        Span<byte> guidBytes = stackalloc byte[16];
        guidBytes.Fill(byte.MaxValue);
        WriteInt64(guidBytes[8..], seq);
        SwapByteOrderForStringOrder(guidBytes);

        return new Guid(guidBytes);
    }

    public static long GetSequence(Guid comb)
    {
        Span<byte> guidBytes = stackalloc byte[16];
        comb.TryWriteBytes(guidBytes);
        SwapByteOrderForStringOrder(guidBytes);

        return ReadInt64(guidBytes[8..]);
    }

    private static void WriteInt64(Span<byte> destination, long value)
    {
        BinaryPrimitives.WriteInt64BigEndian(destination, value);
    }

    private static long ReadInt64(ReadOnlySpan<byte> source)
    {
        return BinaryPrimitives.ReadInt64BigEndian(source);
    }

    private static void SwapByteOrderForStringOrder(Span<byte> input)
    {
        input[..4].Reverse();
        input.Slice(4, 2).Reverse();
    }
}
