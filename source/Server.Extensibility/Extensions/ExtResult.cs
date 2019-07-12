using System.Collections.Generic;
using System.Linq;

namespace Octopus.Server.Extensibility.Extensions
{
    public interface IExtResult
    {
        bool Succeeded { get; }
        string FailureReason { get; }
    }

    public interface IExtResult<out T> : IExtResult
    {
        // Note: be careful about using `IExtResult<T>` as a return type, since it's a reference type that introduces another possibility of a null,
        // inhibits the implicit casts that make `ExtResult<T>` easier to use, and is only marginally more flexible.

        T Value { get; }
    }

    public struct FailureResult : IExtResult
    {
        public bool Succeeded => false;
        public string FailureReason { get; }

        public FailureResult(string failureReason)
        {
            FailureReason = failureReason;
        }
    }

    public struct ExtResult<T> : IExtResult<T>
    {
        public bool Succeeded { get; private set; }
        public string FailureReason { get; private set; }
        public T Value { get; private set; }

        public static ExtResult<T> Success(T value)
        {
            return new ExtResult<T> {Succeeded = true, Value = value};
        }

        public static ExtResult<T> Failure(string reason, T partialValue = default(T))
        {
            return new ExtResult<T> {Succeeded = false, FailureReason = reason, Value = partialValue};
        }

        public static implicit operator ExtResult<T>(T value)
        {
            return Success(value);
        }

        public static implicit operator ExtResult<T>(FailureResult result)
        {
            return new ExtResult<T> {Succeeded = result.Succeeded, FailureReason = result.FailureReason};
        }
    }

    public static class ExtResult
    {
        public static ExtResult<T> Success<T>(T value) => ExtResult<T>.Success(value);

        public static FailureResult Failure(string reason) => new FailureResult(reason);

        public static FailureResult Failure(IExtResult result) => new FailureResult(result.FailureReason);

        public static ExtResult<T> Failure<T>(string reason, T partialValue)
            => ExtResult<T>.Failure(reason, partialValue);

        public static ExtResult<T> Conditional<T>(T value, IEnumerable<IExtResult> dependencies)
        {
            var anyFailure = dependencies.FirstOrDefault(d => !d.Succeeded);
            return anyFailure == null
                ? value
                : Failure(anyFailure.FailureReason, value);
        }

        public static ExtResult<T> Conditional<T, TDep>(T value, IEnumerable<ExtResult<TDep>> dependencies)
            => Conditional(value, dependencies.Cast<IExtResult>());

        public static ExtResult<T> Conditional<T>(T value, params IExtResult[] dependencies)
            => Conditional(value, (IEnumerable<IExtResult>) dependencies);
    }
}