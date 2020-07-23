using System;
using System.Collections.Generic;
using System.Linq;
using Octopus.Data;

namespace Octopus.Server.Extensibility.Results
{
    public interface IResultFromExtension : IResult
    {
    }

    public interface IResultFromExtension<T> : IResult<T>
    {
    }

    public interface ISuccessResultFromExtension : IResultFromExtension
    {
    }

    public interface ISuccessResultFromExtension<T> : ISuccessResult<T>, IResultFromExtension<T>, ISuccessResultFromExtension
    {
    }

    public class ResultFromExtension : Result, IResultFromExtension
    {
        ResultFromExtension()
        {
        }

        public static IFailureResultFromDisabledExtension ExtensionDisabled()
        {
            return new FailureResultFromDisabledExtension();
        }

        public new static IResultFromExtension Success()
        {
            return new ResultFromExtension();
        }

        public static IFailureResultFromExtension Failed()
        {
            return new FailureResultFromExtension(new string[0]);
        }

        public new static IFailureResultFromExtension Failed(params string[] errors)
        {
            return new FailureResultFromExtension(errors);
        }

        public static IFailureResultFromExtension Failed(params FailureResultFromExtension[] becauseOf)
        {
            return new FailureResultFromExtension(becauseOf.SelectMany(b => b.Errors));
        }

        public static IFailureResultFromExtension Failed(IReadOnlyCollection<FailureResultFromExtension> becauseOf)
        {
            return new FailureResultFromExtension(becauseOf.SelectMany(b => b.Errors));
        }
    }

    public class ResultFromExtension<T> : Result<T>, ISuccessResultFromExtension<T>
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