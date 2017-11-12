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

        public static IValitRule<TObject, Guid?> Required<TObject>(this IValitRule<TObject, Guid?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue);

        public static IValitRule<TObject, Guid> IsNotEmpty<TObject>(this IValitRule<TObject, Guid> rule) where TObject : class
            => rule.Satisfies(p => p != Guid.Empty);

        public static IValitRule<TObject, Guid?> IsNotEmpty<TObject>(this IValitRule<TObject, Guid?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value != Guid.Empty);
    }
}