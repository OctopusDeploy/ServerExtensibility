using System;
using System.Collections.Generic;
using Octopus.Data;

namespace Octopus.Server.Extensibility.Results
{
    public class FailureResultFromExtension : FailureResult, IFailureResultFromExtension
    {
        internal FailureResultFromExtension(IEnumerable<string> errors) : base(errors)
        {
        }
    }

    public interface IFailureResultFromExtension : IResultFromExtension
    {
    }

    public interface IFailureResultFromDisabledExtension : IFailureResultFromExtension
    {
    }

    internal class FailureResultFromDisabledExtension : FailureResultFromExtension, IFailureResultFromDisabledExtension
    {
        internal FailureResultFromDisabledExtension() : base(new[] { "Extension disabled" })
        {
        }
    }

    public interface IFailureResultFromDisabledExtension<T> : IFailureResultFromDisabledExtension, IResultFromExtension<T>
    {
    }

    public class FailureResultFromExtension<T> : FailureResultFromExtension, IFailureResultFromDisabledExtension<T>
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