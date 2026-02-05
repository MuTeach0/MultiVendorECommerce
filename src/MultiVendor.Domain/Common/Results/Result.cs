using System.ComponentModel;
using System.Text.Json.Serialization;
using MultiVendor.Domain.Common.Results.Abstractions;

namespace MultiVendor.Domain.Common.Results;
/// <summary>
/// Represents a result of an operation without a return value.
/// </summary>
public class Result : IResult
{
    public bool IsSuccess { get; }
    public bool IsError => !IsSuccess;
    protected readonly List<Error>? _errors;
    public IReadOnlyList<Error> Errors => _errors ?? [];

    protected Result(bool isSuccess, List<Error>? errors)
    {
        IsSuccess = isSuccess;
        _errors = errors;
    }

    // Static Factory Methods
    public static Result Success() => new(true, null);
    public static Result Failure(Error error) => new(false, [error]);
    public static Result Failure(List<Error> errors) => new(false, errors);

    // Static Properties for implicit conversion
    public static Success SuccessValue => default;
    public static Created CreatedValue => default;
    public static Updated UpdatedValue => default;
    public static Deleted DeletedValue => default;

    // Implicit operators for Result (Non-Generic)
    public static implicit operator Result(Success _) => Success();
    public static implicit operator Result(Created _) => Success();
    public static implicit operator Result(Updated _) => Success();
    public static implicit operator Result(Deleted _) => Success();
    public static implicit operator Result(Error error) => Failure(error);
}

/// <summary>
/// Represents a result of an operation with a return value.
/// </summary>
/// <typeparam name="TValue">The type of the result value.</typeparam>
public sealed class Result<TValue> : Result, IResult<TValue>
{
    private readonly TValue? _value;

    [JsonConstructor]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("For serializer only.", true)]
    public Result(TValue? value, List<Error>? errors, bool isSuccess) : base(isSuccess, errors)
    {
        _value = value;
    }

    private Result(TValue value) : base(true, null)
    {
        _value = value ?? throw new ArgumentNullException(nameof(value));
    }

    private Result(Error error) : base(false, [error])
    {
        _value = default;
    }

    private Result(List<Error> errors) : base(false, errors)
    {
        if (errors is null || errors.Count == 0)
            throw new ArgumentException("Provide at least one error.");
        _value = default;
    }

    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("Cannot access Value on a failed result. Use Match() or check IsSuccess.");

    public Error TopError => (IsError && _errors?.Count > 0) ? _errors[0] : default;

    public TNextValue Match<TNextValue>(Func<TValue, TNextValue> onValue, Func<IReadOnlyList<Error>, TNextValue> onError)
        => IsSuccess ? onValue(_value!) : onError(Errors);

    // Implicit Operators for Result<TValue>
    public static implicit operator Result<TValue>(TValue value) => new(value);
    public static implicit operator Result<TValue>(Error error) => new(error);
    public static implicit operator Result<TValue>(List<Error> errors) => new(errors);
    
    // Explicit value types to result conversion
    public static implicit operator Result<TValue>(Success _) => new(default(TValue)!);
    public static implicit operator Result<TValue>(Created _) => new(default(TValue)!);
    public static implicit operator Result<TValue>(Updated _) => new(default(TValue)!);
    public static implicit operator Result<TValue>(Deleted _) => new(default(TValue)!);
}

// Result State Definitions
public readonly record struct Success;
public readonly record struct Created;
public readonly record struct Deleted;
public readonly record struct Updated;