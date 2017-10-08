using System.Runtime.CompilerServices;

namespace Valit.Strategies
{
    public struct DefaultValitStrategies
    {
        static readonly CompleteValitStrategy _Complete = new CompleteValitStrategy();
        static readonly FailFastValitStrategy _FailFast = new FailFastValitStrategy();

        
        public CompleteValitStrategy Complete { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return _Complete; } }

        public FailFastValitStrategy FailFast { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return _FailFast; } }
    }
}
