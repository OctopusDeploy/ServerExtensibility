using System.Collections.Generic;
using System.Linq;

namespace Octopus.Server.Extensibility.Extensions
{
    public interface ISuccessOrErrorResult
    {
        bool Succeeded { get; }
        string FailureReason { get; }
    }

    public interface ISuccessOrErrorResult<out T> : ISuccessOrErrorResult
    {
        // Note: be careful about using `ISuccessOrErrorResult<T>` as a return type, since it's a reference type that introduces another possibility of a null,
        // inhibits the implicit casts that make `SuccessOrErrorResult<T>` easier to use, and is only marginally more flexible.

        T Value { get; }
    }

    public struct ErrorResult : ISuccessOrErrorResult
    {
        public bool Succeeded => false;
        public string FailureReason { get; }

        public ErrorResult(string failureReason)
        {
            FailureReason = failureReason;
        }
    }

    public struct SuccessOrErrorResult<T> : ISuccessOrErrorResult<T>
    {
        public bool Succeeded { get; private set; }
        public string FailureReason { get; private set; }
        public T Value { get; private set; }

        public static SuccessOrErrorResult<T> Success(T value)
        {
            return new SuccessOrErrorResult<T> {Succeeded = true, Value = value};
        }

        public static SuccessOrErrorResult<T> Failure(string reason, T partialValue = default(T))
        {
            return new SuccessOrErrorResult<T> {Succeeded = false, FailureReason = reason, Value = partialValue};
        }

        public static implicit operator SuccessOrErrorResult<T>(T value)
        {
            return Success(value);
        }

        public static implicit operator SuccessOrErrorResult<T>(ErrorResult result)
        {
            return new SuccessOrErrorResult<T> {Succeeded = result.Succeeded, FailureReason = result.FailureReason};
        }
    }

    public static class ExtResult
    {
        public static SuccessOrErrorResult<T> Success<T>(T value) => SuccessOrErrorResult<T>.Success(value);

        public static ErrorResult Failure(string reason) => new ErrorResult(reason);

        public static ErrorResult Failure(ISuccessOrErrorResult result) => new ErrorResult(result.FailureReason);

        public static SuccessOrErrorResult<T> Failure<T>(string reason, T partialValue)
            => SuccessOrErrorResult<T>.Failure(reason, partialValue);

        public static SuccessOrErrorResult<T> Conditional<T>(T value, IEnumerable<ISuccessOrErrorResult> dependencies)
        {
            var anyFailure = dependencies.FirstOrDefault(d => !d.Succeeded);
            return anyFailure == null
                ? value
                : Failure(anyFailure.FailureReason, value);
        }

        public static SuccessOrErrorResult<T> Conditional<T, TDep>(T value, IEnumerable<SuccessOrErrorResult<TDep>> dependencies)
            => Conditional(value, dependencies.Cast<ISuccessOrErrorResult>());

        public static SuccessOrErrorResult<T> Conditional<T>(T value, params ISuccessOrErrorResult[] dependencies)
            => Conditional(value, (IEnumerable<ISuccessOrErrorResult>) dependencies);
    }
}