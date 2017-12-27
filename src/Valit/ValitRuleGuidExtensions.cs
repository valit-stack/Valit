using System;
using Valit.Errors;

namespace Valit
{
    public static class ValitRuleGuidExtensions
    {
        public static IValitRule<TObject, Guid> IsEqualTo<TObject>(this IValitRule<TObject, Guid> rule, Guid value) where TObject : class
            => rule.Satisfies(p => p == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, Guid> IsEqualTo<TObject>(this IValitRule<TObject, Guid> rule, Guid? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, Guid?> IsEqualTo<TObject>(this IValitRule<TObject, Guid?> rule, Guid? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, Guid?> IsEqualTo<TObject>(this IValitRule<TObject, Guid?> rule, Guid value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, Guid?> Required<TObject>(this IValitRule<TObject, Guid?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue).WithDefaultMessage(ErrorMessages.Required);

        public static IValitRule<TObject, Guid> IsNotEmpty<TObject>(this IValitRule<TObject, Guid> rule) where TObject : class
            => rule.Satisfies(p => p != Guid.Empty).WithDefaultMessage(ErrorMessages.IsNotEmpty);

        public static IValitRule<TObject, Guid?> IsNotEmpty<TObject>(this IValitRule<TObject, Guid?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value != Guid.Empty).WithDefaultMessage(ErrorMessages.IsNotEmpty);
    }
}
