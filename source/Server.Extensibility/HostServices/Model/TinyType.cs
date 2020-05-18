using System;

namespace Octopus.Server.Extensibility.HostServices.Model
{
    public abstract class TinyType<T>
    {
        protected TinyType(T value)
        {
            Value = value;
        }

        public T Value { get; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            return obj.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
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