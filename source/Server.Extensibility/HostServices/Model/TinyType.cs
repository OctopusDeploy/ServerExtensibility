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
    }
}