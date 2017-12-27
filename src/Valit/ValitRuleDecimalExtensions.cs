using Valit.Errors;

namespace Valit
{
    public static class ValitRuleDecimalExtensions
    {
        public static IValitRule<TObject, decimal> IsGreaterThan<TObject>(this IValitRule<TObject, decimal> rule, decimal value) where TObject : class
            => rule.Satisfies(p => p > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, decimal> IsGreaterThan<TObject>(this IValitRule<TObject, decimal> rule, decimal? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, decimal?> IsGreaterThan<TObject>(this IValitRule<TObject, decimal?> rule, decimal value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, decimal?> IsGreaterThan<TObject>(this IValitRule<TObject, decimal?> rule, decimal? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, decimal> IsLessThan<TObject>(this IValitRule<TObject, decimal> rule, decimal value) where TObject : class
            => rule.Satisfies(p => p < value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, decimal> IsLessThan<TObject>(this IValitRule<TObject, decimal> rule, decimal? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p < value.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, decimal?> IsLessThan<TObject>(this IValitRule<TObject, decimal?> rule, decimal value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, decimal?> IsLessThan<TObject>(this IValitRule<TObject, decimal?> rule, decimal? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value < value.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, decimal> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, decimal> rule, decimal value) where TObject : class
            => rule.Satisfies(p => p >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, decimal> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, decimal> rule, decimal? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, decimal?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, decimal?> rule, decimal value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, decimal?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, decimal?> rule, decimal? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, decimal> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, decimal> rule, decimal value) where TObject : class
            => rule.Satisfies(p => p <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, decimal> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, decimal> rule, decimal? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, decimal?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, decimal?> rule, decimal value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, decimal?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, decimal?> rule, decimal? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, decimal> IsEqualTo<TObject>(this IValitRule<TObject, decimal> rule, decimal value) where TObject : class
            => rule.Satisfies(p => p == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, decimal> IsEqualTo<TObject>(this IValitRule<TObject, decimal> rule, decimal? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, decimal?> IsEqualTo<TObject>(this IValitRule<TObject, decimal?> rule, decimal value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, decimal?> IsEqualTo<TObject>(this IValitRule<TObject, decimal?> rule, decimal? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, decimal> IsPositive<TObject>(this IValitRule<TObject, decimal> rule) where TObject : class
            => rule.Satisfies(p => p > 0m).WithDefaultMessage(ErrorMessages.IsPositive);

        public static IValitRule<TObject, decimal?> IsPositive<TObject>(this IValitRule<TObject, decimal?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > 0m).WithDefaultMessage(ErrorMessages.IsPositive);

        public static IValitRule<TObject, decimal> IsNegative<TObject>(this IValitRule<TObject, decimal> rule) where TObject : class
            => rule.Satisfies(p => p < 0m).WithDefaultMessage(ErrorMessages.IsNegative);

        public static IValitRule<TObject, decimal?> IsNegative<TObject>(this IValitRule<TObject, decimal?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < 0m).WithDefaultMessage(ErrorMessages.IsNegative);

        public static IValitRule<TObject, decimal> IsNonZero<TObject>(this IValitRule<TObject, decimal> rule) where TObject : class
            => rule.Satisfies(p => p != 0m).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, decimal?> IsNonZero<TObject>(this IValitRule<TObject, decimal?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value != 0m).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, decimal?> Required<TObject>(this IValitRule<TObject, decimal?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue).WithDefaultMessage(ErrorMessages.Required);

    }
}
