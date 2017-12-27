using System;
using Valit.Errors;

namespace Valit
{
    public static class ValitRuleTimeSpanExtensions
    {
        public static IValitRule<TObject, TimeSpan> IsGreaterThan<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan value) where TObject : class
            => rule.Satisfies(p => p > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, TimeSpan> IsGreaterThan<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, TimeSpan?> IsGreaterThan<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, TimeSpan?> IsGreaterThan<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, TimeSpan> IsLessThan<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan value) where TObject : class
            => rule.Satisfies(p => p < value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, TimeSpan> IsLessThan<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p < value.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, TimeSpan?> IsLessThan<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, TimeSpan?> IsLessThan<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value < value.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, TimeSpan> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan value) where TObject : class
            => rule.Satisfies(p => p >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, TimeSpan> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, TimeSpan?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, TimeSpan?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, TimeSpan> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan value) where TObject : class
            => rule.Satisfies(p => p <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, TimeSpan> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, TimeSpan?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, TimeSpan?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, TimeSpan> IsEqualTo<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan value) where TObject : class
            => rule.Satisfies(p => p == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, TimeSpan> IsEqualTo<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, TimeSpan?> IsEqualTo<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, TimeSpan?> IsEqualTo<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, TimeSpan> IsNonZero<TObject>(this IValitRule<TObject, TimeSpan> rule) where TObject : class
            => rule.Satisfies(p => p != TimeSpan.Zero).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, TimeSpan?> IsNonZero<TObject>(this IValitRule<TObject, TimeSpan?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value != TimeSpan.Zero).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, TimeSpan?> Required<TObject>(this IValitRule<TObject, TimeSpan?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue).WithDefaultMessage(ErrorMessages.Required);
    }
}
