using CSharpFunctionalExtensions;

namespace Rinha.MMXXIV.Q1.Core.Common;

public static class ResultExtensions
{
    public static Result<TValue2, TError2> Convert<TValue1, TError1, TValue2, TError2>(
        this in Result<TValue1, TError1> result,
        Func<TValue1, TValue2> successMapper,
        Func<TError1, TError2> errorMapper) =>
        result.Map(successMapper).MapError(errorMapper);

    public static Task<Result<TValue2, TError2>> Convert<TValue1, TError1, TValue2, TError2>(
        this Task<Result<TValue1, TError1>> result,
        Func<TValue1, TValue2> successMapper,
        Func<TError1, TError2> errorMapper) =>
        result.Map(successMapper).MapError(errorMapper);
}
