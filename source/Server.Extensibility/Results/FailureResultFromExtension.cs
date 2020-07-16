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

    public class FailureResultFromDisabledExtension : FailureResultFromExtension
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

    public class FailureResultFromDisabledExtension<T> : FailureResultFromExtension<T>
    {
        internal FailureResultFromDisabledExtension() : base(new[] { "Extension disabled" })
        {
        }
    }
}