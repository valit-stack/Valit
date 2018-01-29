using Valit.Errors;

namespace Valit
{
    public static class ValitRuleBooleanExtensions
    {
        public static IValitRule<TObject, bool> IsTrue<TObject>(this IValitRule<TObject, bool> rule) where TObject : class
            => rule.Satisfies(p => p).WithDefaultMessage(ErrorMessages.IsTrue);

        public static IValitRule<TObject, bool?> IsTrue<TObject>(this IValitRule<TObject, bool?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p == true).WithDefaultMessage(ErrorMessages.IsTrue);

        public static IValitRule<TObject, bool> IsFalse<TObject>(this IValitRule<TObject, bool> rule) where TObject : class
            => rule.Satisfies(p => !p).WithDefaultMessage(ErrorMessages.IsFalse);

        public static IValitRule<TObject, bool?> IsFalse<TObject>(this IValitRule<TObject, bool?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p == false).WithDefaultMessage(ErrorMessages.IsFalse);

        public static IValitRule<TObject, bool> IsEqualTo<TObject>(this IValitRule<TObject, bool> rule, bool value) where TObject : class
            => rule.Satisfies(p => p == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, bool> IsEqualTo<TObject>(this IValitRule<TObject, bool> rule, bool? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, bool?> IsEqualTo<TObject>(this IValitRule<TObject, bool?> rule, bool value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, bool?> IsEqualTo<TObject>(this IValitRule<TObject, bool?> rule, bool? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, bool?> Required<TObject>(this IValitRule<TObject, bool?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue).WithDefaultMessage(ErrorMessages.Required);
    }
}
