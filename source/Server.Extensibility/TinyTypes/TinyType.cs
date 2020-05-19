using System;

namespace Octopus.Server.Extensibility.TinyTypes
{
    /// <summary>
    ///     Provides a strongly-typed wrapper around a (ideally value) type.
    /// </summary>
    /// <remarks>
    ///     NOTE: We deliberately do not provide implicit or explicit cast operators. Implicit cases would defeat the purpose
    ///     of providing compile-time errors when disparate types are compared or passed as parameters. Explicit cast operators
    ///     would not cause this problem... but they would be *so very tempting* that it's inevitable that they'd end up being
    ///     used to coerce types between values that really shouldn't be coerced. The design decision at present is that tiny
    ///     types must be explicitly unwrapped and re-wrapped in order to minimise the likelihood of bugs' being created.
    /// </remarks>
    public abstract class TinyType<T>
    {
        protected TinyType(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value),
                    "Tiny type values should never be null. If the value you want to communicate is null then " +
                    "just pass a null rather than a tiny type wrapping a null.");

            Value = value;
        }

        public T Value { get; }

        public override bool Equals(object obj)
        {
            if (Equals(obj, null)) return false;
            if (obj.GetType() != GetType()) return false;
            return obj.GetHashCode() == GetHashCode();
        }

        public static bool operator ==(TinyType<T> a, TinyType<T> b)
        {
            if (Equals(a, null) && Equals(b, null)) return true;
            if (Equals(a, null)) return false;

            return a.Equals(b);
        }

        public static bool operator !=(TinyType<T> a, TinyType<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value?.ToString() ?? string.Empty;
        }

        public static TTinyType Create<TTinyType>(T value) where TTinyType : TinyType<T>
        {
            // TODO we can optimise this by emitting IL instead. Feel free, if this method ever actually
            // appears in a .dotTrace hotspot list :)

            var instance = (TTinyType) Activator.CreateInstance(typeof(TTinyType), value);
            return instance;
        }
    }
}