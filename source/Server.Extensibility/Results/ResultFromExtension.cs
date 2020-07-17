using System;
using System.Collections.Generic;
using System.Linq;
using Octopus.Data;

namespace Octopus.Server.Extensibility.Results
{
    public interface IResultFromExtension : IResult
    {
    }

    public interface IResultFromExtension<T> : IResult<T>, IResultFromExtension
    {
    }

    public class ResultFromExtension : Result
    {
        ResultFromExtension()
        {
        }

        public static FailureResultFromDisabledExtension ExtensionDisabled()
        {
            return new FailureResultFromDisabledExtension();
        }

        public static FailureResultFromExtension Failed()
        {
            return new FailureResultFromExtension(new string[0]);
        }

        public new static FailureResultFromExtension Failed(params string[] errors)
        {
            return new FailureResultFromExtension(errors);
        }

        public static FailureResultFromExtension Failed(params FailureResultFromExtension[] becauseOf)
        {
            return new FailureResultFromExtension(becauseOf.SelectMany(b => b.Errors));
        }

        public static FailureResultFromExtension Failed(IReadOnlyCollection<FailureResultFromExtension> becauseOf)
        {
            return new FailureResultFromExtension(becauseOf.SelectMany(b => b.Errors));
        }
    }

    public class ResultFromExtension<T> : Result<T>, IResultFromExtension<T>
    {
        ResultFromExtension(T value) : base(value)
        {
        }

        public static FailureResultFromDisabledExtension<T> ExtensionDisabled()
        {
            return new FailureResultFromDisabledExtension<T>();
        }

        public new static ResultFromExtension<T> Success(T value)
        {
            return new ResultFromExtension<T>(value);
        }

        public static FailureResultFromExtension<T> Failed()
        {
            return new FailureResultFromExtension<T>(new string[0]);
        }

        public new static FailureResultFromExtension<T> Failed(params string[] errors)
        {
            return new FailureResultFromExtension<T>(errors);
        }

        public static FailureResultFromExtension<T> Failed(params FailureResultFromExtension[] becauseOf)
        {
            return new FailureResultFromExtension<T>(becauseOf.SelectMany(b => b.Errors));
        }

        public static FailureResultFromExtension<T> Failed(IReadOnlyCollection<FailureResultFromExtension> becauseOf)
        {
            return new FailureResultFromExtension<T>(becauseOf.SelectMany(b => b.Errors));
        }
    }
}