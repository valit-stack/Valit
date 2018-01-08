using Valit.Exceptions;
using Valit.Validators;

namespace Valit
{
    public static class ValitRulesProviderExtensions
    {
        public static IValitator<TObject> CreateValitator<TObject>(this IValitRules<TObject> valitRules) where TObject : class
        {
            valitRules.ThrowIfNull();
            return new Valitator<TObject>(valitRules);
        }
    }
}
