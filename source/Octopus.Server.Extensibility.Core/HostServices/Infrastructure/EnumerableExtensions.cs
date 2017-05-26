using System;
using System.Collections.Generic;

namespace Octopus.Server.Extensibility.HostServices.Infrastructure
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> these, Action<T> action)
        {
            foreach (var x in these)
                action(x);
        }
    }
}