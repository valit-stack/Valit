using Valit.Errors;

namespace Valit
{
    public static class ValitRuleInt64Extensions
    {
        public static IValitRule<TObject, long> IsGreaterThan<TObject>(this IValitRule<TObject, long> rule, long value) where TObject : class
            => rule.Satisfies(p => p > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, long> IsGreaterThan<TObject>(this IValitRule<TObject, long> rule, long? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);


        public static IValitRule<TObject, long?> IsGreaterThan<TObject>(this IValitRule<TObject, long?> rule, long value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, long?> IsGreaterThan<TObject>(this IValitRule<TObject, long?> rule, long? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);


        public static IValitRule<TObject, long> IsLessThan<TObject>(this IValitRule<TObject, long> rule, long value) where TObject : class
            => rule.Satisfies(p => p < value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, long> IsLessThan<TObject>(this IValitRule<TObject, long> rule, long? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p < value.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);


        public static IValitRule<TObject, long?> IsLessThan<TObject>(this IValitRule<TObject, long?> rule, long value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, long?> IsLessThan<TObject>(this IValitRule<TObject, long?> rule, long? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value < value.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);


        public static IValitRule<TObject, long> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, long> rule, long value) where TObject : class
            => rule.Satisfies(p => p >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, long> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, long> rule, long? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);


        public static IValitRule<TObject, long?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, long?> rule, long value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, long?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, long?> rule, long? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);


        public static IValitRule<TObject, long> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, long> rule, long value) where TObject : class
            => rule.Satisfies(p => p <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, long> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, long> rule, long? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);


        public static IValitRule<TObject, long?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, long?> rule, long value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, long?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, long?> rule, long? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);


        public static IValitRule<TObject, long> IsEqualTo<TObject>(this IValitRule<TObject, long> rule, long value) where TObject : class
            => rule.Satisfies(p => p == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, long> IsEqualTo<TObject>(this IValitRule<TObject, long> rule, long? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);


        public static IValitRule<TObject, long?> IsEqualTo<TObject>(this IValitRule<TObject, long?> rule, long value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, long?> IsEqualTo<TObject>(this IValitRule<TObject, long?> rule, long? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);


        public static IValitRule<TObject, long> IsPositive<TObject>(this IValitRule<TObject, long> rule) where TObject : class
            => rule.Satisfies(p => p > 0L).WithDefaultMessage(ErrorMessages.IsPositive);

        public static IValitRule<TObject, long?> IsPositive<TObject>(this IValitRule<TObject, long?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > 0L).WithDefaultMessage(ErrorMessages.IsPositive);

        public static IValitRule<TObject, long> IsNegative<TObject>(this IValitRule<TObject, long> rule) where TObject : class
            => rule.Satisfies(p => p < 0L).WithDefaultMessage(ErrorMessages.IsNegative);

        public static IValitRule<TObject, long?> IsNegative<TObject>(this IValitRule<TObject, long?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < 0L).WithDefaultMessage(ErrorMessages.IsNegative);

        public static IValitRule<TObject, long> IsNonZero<TObject>(this IValitRule<TObject, long> rule) where TObject : class
            => rule.Satisfies(p => p != 0L).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, long?> IsNonZero<TObject>(this IValitRule<TObject, long?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value != 0L).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, long?> Required<TObject>(this IValitRule<TObject, long?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue).WithDefaultMessage(ErrorMessages.Required);
    }
}
