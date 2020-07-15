using System;
using System.Collections.Generic;
using System.Linq;
using Octopus.Data;

namespace Octopus.Server.Extensibility.Results
{
    public class ResultFromExtension<T> : Result<T>
    {
        protected ResultFromExtension()
        {
        }

        public bool ExtensionIsDisabled { get; private set; }

        public static ResultFromExtension<T> ExtensionDisabled()
        {
            return new ResultFromExtension<T> { ExtensionIsDisabled = true };
        }

        public new static ResultFromExtension<T> Success(T value)
        {
            return new ResultFromExtension<T>
                { WasSuccessful = true, Value = value };
        }

        public new static ResultFromExtension<T> Failed()
        {
            return new ResultFromExtension<T>
                { Errors = new string[0] };
        }

        public new static ResultFromExtension<T> Failed(params string[] errors)
        {
            return new ResultFromExtension<T>
                { Errors = errors.ToArray() };
        }

        public new static ResultFromExtension<T> Failed(params IResult[] becauseOf)
        {
            return new ResultFromExtension<T>
                { Errors = becauseOf.Where(s => s.WasFailure).SelectMany(b => b.Errors).ToArray() };
        }

        public new static ResultFromExtension<T> Failed(IReadOnlyCollection<IResult> becauseOf)
        {
            return new ResultFromExtension<T>
                { Errors = becauseOf.Where(s => s.WasFailure).SelectMany(b => b.Errors).ToArray() };
        }
    }
}