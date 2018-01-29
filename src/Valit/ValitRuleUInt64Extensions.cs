using Valit.Errors;

namespace Valit
{
    public static class ValitRuleUInt64Extensions
    {
        public static IValitRule<TObject, ulong> IsGreaterThan<TObject>(this IValitRule<TObject, ulong> rule, ulong value) where TObject : class
            => rule.Satisfies(p => p > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, ulong> IsGreaterThan<TObject>(this IValitRule<TObject, ulong> rule, ulong? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);


        public static IValitRule<TObject, ulong?> IsGreaterThan<TObject>(this IValitRule<TObject, ulong?> rule, ulong value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, ulong?> IsGreaterThan<TObject>(this IValitRule<TObject, ulong?> rule, ulong? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);


        public static IValitRule<TObject, ulong> IsLessThan<TObject>(this IValitRule<TObject, ulong> rule, ulong value) where TObject : class
            => rule.Satisfies(p => p < value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, ulong> IsLessThan<TObject>(this IValitRule<TObject, ulong> rule, ulong? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p < value.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);


        public static IValitRule<TObject, ulong?> IsLessThan<TObject>(this IValitRule<TObject, ulong?> rule, ulong value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, ulong?> IsLessThan<TObject>(this IValitRule<TObject, ulong?> rule, ulong? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value < value.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);


        public static IValitRule<TObject, ulong> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, ulong> rule, ulong value) where TObject : class
            => rule.Satisfies(p => p >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, ulong> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, ulong> rule, ulong? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);


        public static IValitRule<TObject, ulong?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, ulong?> rule, ulong value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, ulong?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, ulong?> rule, ulong? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);


        public static IValitRule<TObject, ulong> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, ulong> rule, ulong value) where TObject : class
            => rule.Satisfies(p => p <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, ulong> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, ulong> rule, ulong? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);


        public static IValitRule<TObject, ulong?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, ulong?> rule, ulong value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, ulong?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, ulong?> rule, ulong? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, ulong> IsEqualTo<TObject>(this IValitRule<TObject, ulong> rule, ulong value) where TObject : class
            => rule.Satisfies(p => p == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, ulong> IsEqualTo<TObject>(this IValitRule<TObject, ulong> rule, ulong? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);


        public static IValitRule<TObject, ulong?> IsEqualTo<TObject>(this IValitRule<TObject, ulong?> rule, ulong value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, ulong?> IsEqualTo<TObject>(this IValitRule<TObject, ulong?> rule, ulong? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);


        public static IValitRule<TObject, ulong> IsNonZero<TObject>(this IValitRule<TObject, ulong> rule) where TObject : class
            => rule.Satisfies(p => p != 0UL).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, ulong?> IsNonZero<TObject>(this IValitRule<TObject, ulong?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value != 0UL).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, ulong?> Required<TObject>(this IValitRule<TObject, ulong?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue).WithDefaultMessage(ErrorMessages.Required);
    }
}
