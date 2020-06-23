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

    }
}