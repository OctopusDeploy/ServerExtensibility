namespace Octopus.Server.Extensibility.HostServices.Model
{
    public abstract class CaseInsensitiveStringTinyType: TinyType<string>
    {
        protected CaseInsensitiveStringTinyType(string value) : base(value)
        {
        }

        public override int GetHashCode()
        {
            return Value.ToUpperInvariant().GetHashCode();
        }
    }
}