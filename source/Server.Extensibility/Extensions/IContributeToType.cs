namespace Octopus.Server.Extensibility.Extensions
{
    public interface IContributeToType<T>
    {
        void ContributeTo(T instance);
    }
}