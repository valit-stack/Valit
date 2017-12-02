using Valit.Exceptions;
using Valit.Validators;

namespace Valit
{
    public static class ValitRulesProviderExtensions
    {
        public static IValitator<TObject> CreateValitator<TObject>(this IValitRulesProvider<TObject> valitRulesProvider) where TObject : class
        {
            valitRulesProvider.ThrowIfNull();
            return new Valitator<TObject>(valitRulesProvider);
        }
    }
}
