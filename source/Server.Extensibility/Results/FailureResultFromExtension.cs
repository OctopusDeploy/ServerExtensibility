using System;
using System.Collections.Generic;
using Octopus.Data;

namespace Octopus.Server.Extensibility.Results
{
    public class FailureResultFromExtension : FailureResult
    {
        internal FailureResultFromExtension(IEnumerable<string> errors) : base(errors)
        {
        }
    }

    public interface IFailureResultFromDisabledExtension
    {
    }

    public class FailureResultFromDisabledExtension : FailureResultFromExtension, IFailureResultFromDisabledExtension
    {
        internal FailureResultFromDisabledExtension() : base(new[] { "Extension disabled" })
        {
        }
    }

    public class FailureResultFromExtension<T> : FailureResultFromExtension, IResultFromExtension<T>
    {
        internal FailureResultFromExtension(IEnumerable<string> errors) : base(errors)
        {
        }
    }

    public class FailureResultFromDisabledExtension<T> : FailureResultFromExtension<T>, IFailureResultFromDisabledExtension
    {
        internal FailureResultFromDisabledExtension() : base(new[] { "Extension disabled" })
        {
        }
    }
}