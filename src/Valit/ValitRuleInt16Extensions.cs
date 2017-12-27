using Valit.Errors;

namespace Valit
{
    public static class ValitRuleInt16Extensions
    {
        public static IValitRule<TObject, short> IsGreaterThan<TObject>(this IValitRule<TObject, short> rule, short value) where TObject : class
            => rule.Satisfies(p => p > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, short> IsGreaterThan<TObject>(this IValitRule<TObject, short> rule, short? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, short?> IsGreaterThan<TObject>(this IValitRule<TObject, short?> rule, short value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, short?> IsGreaterThan<TObject>(this IValitRule<TObject, short?> rule, short? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, short> IsLessThan<TObject>(this IValitRule<TObject, short> rule, short value) where TObject : class
            => rule.Satisfies(p => p < value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, short> IsLessThan<TObject>(this IValitRule<TObject, short> rule, short? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p < value.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, short?> IsLessThan<TObject>(this IValitRule<TObject, short?> rule, short value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, short?> IsLessThan<TObject>(this IValitRule<TObject, short?> rule, short? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value < value.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, short> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, short> rule, short value) where TObject : class
            => rule.Satisfies(p => p >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, short> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, short> rule, short? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, short?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, short?> rule, short value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, short?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, short?> rule, short? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, short> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, short> rule, short value) where TObject : class
            => rule.Satisfies(p => p <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, short> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, short> rule, short? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, short?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, short?> rule, short value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, short?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, short?> rule, short? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, short> IsEqualTo<TObject>(this IValitRule<TObject, short> rule, short value) where TObject : class
            => rule.Satisfies(p => p == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, short> IsEqualTo<TObject>(this IValitRule<TObject, short> rule, short? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, short?> IsEqualTo<TObject>(this IValitRule<TObject, short?> rule, short value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, short?> IsEqualTo<TObject>(this IValitRule<TObject, short?> rule, short? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, short> IsPositive<TObject>(this IValitRule<TObject, short> rule) where TObject : class
            => rule.Satisfies(p => p > 0).WithDefaultMessage(ErrorMessages.IsPositive);

        public static IValitRule<TObject, short?> IsPositive<TObject>(this IValitRule<TObject, short?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > 0).WithDefaultMessage(ErrorMessages.IsPositive);

        public static IValitRule<TObject, short> IsNegative<TObject>(this IValitRule<TObject, short> rule) where TObject : class
            => rule.Satisfies(p => p < 0).WithDefaultMessage(ErrorMessages.IsNegative);

        public static IValitRule<TObject, short?> IsNegative<TObject>(this IValitRule<TObject, short?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < 0).WithDefaultMessage(ErrorMessages.IsNegative);

        public static IValitRule<TObject, short> IsNonZero<TObject>(this IValitRule<TObject, short> rule) where TObject : class
            => rule.Satisfies(p => p != 0).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, short?> IsNonZero<TObject>(this IValitRule<TObject, short?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value != 0).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, short?> Required<TObject>(this IValitRule<TObject, short?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue).WithDefaultMessage(ErrorMessages.Required);
    }
}
