using Valit.Errors;

namespace Valit
{
    public static class ValitRuleInt32Extensions
    {
        public static IValitRule<TObject, int> IsGreaterThan<TObject>(this IValitRule<TObject, int> rule, int value) where TObject : class
            => rule.Satisfies(p => p > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, int> IsGreaterThan<TObject>(this IValitRule<TObject, int> rule, int? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, int?> IsGreaterThan<TObject>(this IValitRule<TObject, int?> rule, int value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, int?> IsGreaterThan<TObject>(this IValitRule<TObject, int?> rule, int? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, int> IsLessThan<TObject>(this IValitRule<TObject, int> rule, int value) where TObject : class
            => rule.Satisfies(p => p < value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, int> IsLessThan<TObject>(this IValitRule<TObject, int> rule, int? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p < value.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, int?> IsLessThan<TObject>(this IValitRule<TObject, int?> rule, int value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, int?> IsLessThan<TObject>(this IValitRule<TObject, int?> rule, int? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value < value.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, int> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, int> rule, int value) where TObject : class
            => rule.Satisfies(p => p >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, int> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, int> rule, int? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, int?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, int?> rule, int value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, int?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, int?> rule, int? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, int> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, int> rule, int value) where TObject : class
            => rule.Satisfies(p => p <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, int> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, int> rule, int? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, int?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, int?> rule, int value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, int?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, int?> rule, int? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, int> IsEqualTo<TObject>(this IValitRule<TObject, int> rule, int value) where TObject : class
            => rule.Satisfies(p => p == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, int> IsEqualTo<TObject>(this IValitRule<TObject, int> rule, int? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, int?> IsEqualTo<TObject>(this IValitRule<TObject, int?> rule, int value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, int?> IsEqualTo<TObject>(this IValitRule<TObject, int?> rule, int? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, int> IsPositive<TObject>(this IValitRule<TObject, int> rule) where TObject : class
            => rule.Satisfies(p => p > 0).WithDefaultMessage(ErrorMessages.IsPositive);

        public static IValitRule<TObject, int?> IsPositive<TObject>(this IValitRule<TObject, int?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > 0).WithDefaultMessage(ErrorMessages.IsPositive);

        public static IValitRule<TObject, int> IsNegative<TObject>(this IValitRule<TObject, int> rule) where TObject : class
            => rule.Satisfies(p => p < 0).WithDefaultMessage(ErrorMessages.IsNegative);

        public static IValitRule<TObject, int?> IsNegative<TObject>(this IValitRule<TObject, int?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < 0).WithDefaultMessage(ErrorMessages.IsNegative);

        public static IValitRule<TObject, int> IsNonZero<TObject>(this IValitRule<TObject, int> rule) where TObject : class
            => rule.Satisfies(p => p != 0).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, int?> IsNonZero<TObject>(this IValitRule<TObject, int?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value != 0).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, int?> Required<TObject>(this IValitRule<TObject, int?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue).WithDefaultMessage(ErrorMessages.Required);
    }
}
