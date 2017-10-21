using static Valit.Exceptions.SemanticExceptions;

namespace Valit
{
    internal static class ValitRuleAccessorExtensions
    {
        internal static IValitRuleAccessor<TObject, TProperty> GetAccessor<TObject, TProperty>(this IValitRule<TObject, TProperty> rule) where TObject : class
        {
            var accessor = rule as IValitRuleAccessor<TObject, TProperty>;

            if (accessor == null)
            {
                throw MissingRuleAccessor();
            }

            return accessor;
        }       
    }
}
