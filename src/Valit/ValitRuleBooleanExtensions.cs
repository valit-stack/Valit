namespace Valit
{
    public static class ValitRuleBooleanExtensions
    {
        public static IValitRule<TObject, bool> IsTrue<TObject>(this IValitRule<TObject, bool> rule) where TObject : class
            => rule.Satisfies(p => p);

        public static IValitRule<TObject, bool?> IsTrue<TObject>(this IValitRule<TObject, bool?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p == true);

        public static IValitRule<TObject, bool> IsFalse<TObject>(this IValitRule<TObject, bool> rule) where TObject : class
            => rule.Satisfies(p => !p);

        public static IValitRule<TObject, bool?> IsFalse<TObject>(this IValitRule<TObject, bool?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p == false);

        public static IValitRule<TObject, bool> IsEqualTo<TObject>(this IValitRule<TObject, bool> rule, bool value) where TObject : class
            => rule.Satisfies(p => p == value);

        public static IValitRule<TObject, bool> IsEqualTo<TObject>(this IValitRule<TObject, bool> rule, bool? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p == value.Value);

        public static IValitRule<TObject, bool?> IsEqualTo<TObject>(this IValitRule<TObject, bool?> rule, bool value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value == value);

        public static IValitRule<TObject, bool?> IsEqualTo<TObject>(this IValitRule<TObject, bool?> rule, bool? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value == value.Value);

        public static IValitRule<TObject, bool?> Required<TObject>(this IValitRule<TObject, bool?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue);
    }
}
