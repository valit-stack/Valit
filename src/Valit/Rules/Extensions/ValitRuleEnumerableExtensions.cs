using System.Collections;

namespace Valit
{
    public static class ValitRuleEnumerableExtensions
    {     

        public static IValitRule<TObject, IEnumerable> MinItems<TObject>(this IValitRule<TObject, IEnumerable> rule, int expectedItemsNumber) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);             
            return rule.Satisfies(p => p != null && p.Count() >= expectedItemsNumber);
        }

        public static IValitRule<TObject, IEnumerable> MaxItems<TObject>(this IValitRule<TObject, IEnumerable> rule, int expectedItemsNumber) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);             
            return rule.Satisfies(p => p != null && p.Count() <= expectedItemsNumber);
        }
    }
}