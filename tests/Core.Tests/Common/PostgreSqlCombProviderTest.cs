using FluentAssertions;
using Rinha.MMXXIV.Q1.Core.Common;

namespace Rinha.MMXXIV.Q1.Core.Tests.Common;

public class PostgreSqlCombProviderTest
{
    [Theory]
    [InlineData(1L, "ffffffff-ffff-ffff-0000-000000000001")]
    [InlineData(2L, "ffffffff-ffff-ffff-0000-000000000002")]
    [InlineData(3L, "ffffffff-ffff-ffff-0000-000000000003")]
    [InlineData(10L, "ffffffff-ffff-ffff-0000-00000000000a")]
    public void ShouldConvertNumberToGuid(long number, Guid expected)
    {
        PostgreSqlCombProvider.Create(number).Should().Be(expected);
    }

    [Theory]
    [InlineData("00000000-0000-0100-0000-000000000001", 1L)]
    [InlineData("00000000-0000-0200-0000-000000000002", 2L)]
    [InlineData("00000000-0000-0300-0000-000000000003", 3L)]
    [InlineData("00000000-0000-0a00-0000-00000000000a", 10L)]
    [InlineData("ffffffff-ffff-ffff-0000-000000000001", 1L)]
    [InlineData("ffffffff-ffff-ffff-0000-000000000002", 2L)]
    [InlineData("ffffffff-ffff-ffff-0000-000000000003", 3L)]
    [InlineData("ffffffff-ffff-ffff-0000-00000000000a", 10L)]
    public void ShouldConvertGuidToNumber(Guid value, long expected)
    {
        PostgreSqlCombProvider.GetSequence(value).Should().Be(expected);
    }
}
