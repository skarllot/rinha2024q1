using FluentAssertions;
using Rinha.MMXXIV.Q1.Core.Common;

namespace Rinha.MMXXIV.Q1.Core.Tests.Common;

public class IntAsGuidConverterTest
{
    [Theory]
    [InlineData(1L, "00000000-0000-0100-0000-000000000000")]
    [InlineData(2L, "00000000-0000-0200-0000-000000000000")]
    [InlineData(3L, "00000000-0000-0300-0000-000000000000")]
    [InlineData(10L, "00000000-0000-0a00-0000-000000000000")]
    public void ShouldConvertNumberToGuid(long number, Guid expected)
    {
        number.AsCombGuid().Should().Be(expected);
    }

    [Theory]
    [InlineData("00000000-0000-0100-0000-000000000000", 1L)]
    [InlineData("00000000-0000-0200-0000-000000000000", 2L)]
    [InlineData("00000000-0000-0300-0000-000000000000", 3L)]
    [InlineData("00000000-0000-0a00-0000-000000000000", 10L)]
    public void ShouldConvertGuidToNumber(Guid value, long expected)
    {
        value.ToInt64().Should().Be(expected);
    }
}
