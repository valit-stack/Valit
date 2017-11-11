using System;

namespace Valit
{
    public static class ValitRuleGuidExtensions
    {
        public static IValitRule<TObject, Guid> IsEqualTo<TObject>(this IValitRule<TObject, Guid> rule, Guid guid) where TObject : class
            => rule.Satisfies(p => p == guid);
        
        public static IValitRule<TObject, Guid> IsEqualTo<TObject>(this IValitRule<TObject, Guid> rule, Guid? guid) where TObject : class
            => rule.Satisfies(p => guid.HasValue && p == guid.Value);
        
        public static IValitRule<TObject, Guid?> IsEqualTo<TObject>(this IValitRule<TObject, Guid?> rule, Guid? guid) where TObject : class
            => rule.Satisfies(p => p.HasValue && guid.HasValue && p.Value == guid.Value);

        public static IValitRule<TObject, Guid?> IsEqualTo<TObject>(this IValitRule<TObject, Guid?> rule, Guid guid) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value == guid);
    }
}