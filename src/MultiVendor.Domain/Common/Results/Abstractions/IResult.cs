namespace MultiVendor.Domain.Common.Results.Abstractions;

public interface IResult
{
    IReadOnlyList<Error> Errors { get; }
    bool IsError { get; }
    bool IsSuccess { get; }
}

public interface IResult<out TValue> : IResult
{
    TValue Value { get; }
}