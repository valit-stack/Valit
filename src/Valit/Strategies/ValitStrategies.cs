using System.Runtime.CompilerServices;

namespace Valit.Strategies
{
    public struct DefaultValitStrategies
    {
        static readonly CompleteValitStrategy _complete = new CompleteValitStrategy();
        static readonly FailFastValitStrategy _failFast = new FailFastValitStrategy();
        
        public CompleteValitStrategy Complete => _complete;

        public FailFastValitStrategy FailFast => _failFast;
    }
}
