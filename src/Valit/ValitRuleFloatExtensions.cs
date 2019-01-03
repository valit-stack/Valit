using System;
using Valit.Errors;

namespace Valit
{
    public static class ValitRuleFloatExtensions
    {
        public static IValitRule<TObject, float> IsGreaterThan<TObject>(this IValitRule<TObject, float> rule, float value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && !Single.IsNaN(value) && p > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, float> IsGreaterThan<TObject>(this IValitRule<TObject, float> rule, float? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Single.IsNaN(p) && !Single.IsNaN(value.Value) && p > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, float?> IsGreaterThan<TObject>(this IValitRule<TObject, float?> rule, float value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value) && p.Value > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, float?> IsGreaterThan<TObject>(this IValitRule<TObject, float?> rule, float? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value.Value) && p.Value > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, float> IsLessThan<TObject>(this IValitRule<TObject, float> rule, float value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && !Single.IsNaN(value) && value > p).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, float> IsLessThan<TObject>(this IValitRule<TObject, float> rule, float? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Single.IsNaN(p) && !Single.IsNaN(value.Value) && value.Value > p).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, float?> IsLessThan<TObject>(this IValitRule<TObject, float?> rule, float value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value) && value > p.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, float?> IsLessThan<TObject>(this IValitRule<TObject, float?> rule, float? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value.Value) && value.Value > p.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, float> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, float> rule, float value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && !Single.IsNaN(value) && p >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, float> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, float> rule, float? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Single.IsNaN(p) && !Single.IsNaN(value.Value) && p >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, float?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, float?> rule, float value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value) && p.Value >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, float?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, float?> rule, float? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value.Value) && p.Value >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, float> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, float> rule, float value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && !Single.IsNaN(value) && p <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, float> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, float> rule, float? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Single.IsNaN(p) && !Single.IsNaN(value.Value) && p <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, float?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, float?> rule, float value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value) && p.Value <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, float?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, float?> rule, float? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value.Value) && p.Value <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, float> IsEqualTo<TObject>(this IValitRule<TObject, float> rule, float value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && !Single.IsNaN(value) && p == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, float> IsEqualTo<TObject>(this IValitRule<TObject, float> rule, float? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Single.IsNaN(p) && !Single.IsNaN(value.Value) && p == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, float?> IsEqualTo<TObject>(this IValitRule<TObject, float?> rule, float value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value) && p.Value == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, float?> IsEqualTo<TObject>(this IValitRule<TObject, float?> rule, float? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value.Value) && p.Value == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, float> IsPositive<TObject>(this IValitRule<TObject, float> rule, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && p > 0f).WithDefaultMessage(ErrorMessages.IsPositive);

        public static IValitRule<TObject, float?> IsPositive<TObject>(this IValitRule<TObject, float?> rule, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && p.Value > 0f).WithDefaultMessage(ErrorMessages.IsPositive);

        public static IValitRule<TObject, float> IsNegative<TObject>(this IValitRule<TObject, float> rule, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && p < 0f).WithDefaultMessage(ErrorMessages.IsNegative);

        public static IValitRule<TObject, float?> IsNegative<TObject>(this IValitRule<TObject, float?> rule, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && p.Value < 0f).WithDefaultMessage(ErrorMessages.IsNegative);

        public static IValitRule<TObject, float> IsNonZero<TObject>(this IValitRule<TObject, float> rule, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && p != 0f).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, float?> IsNonZero<TObject>(this IValitRule<TObject, float?> rule, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && p.Value != 0f).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, float> IsNumber<TObject>(this IValitRule<TObject, float> rule) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p)).WithDefaultMessage(ErrorMessages.IsNumber);

        public static IValitRule<TObject, float?> IsNumber<TObject>(this IValitRule<TObject, float?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value)).WithDefaultMessage(ErrorMessages.IsNumber);

        public static IValitRule<TObject, float> IsNaN<TObject>(this IValitRule<TObject, float> rule) where TObject : class
            => rule.Satisfies(p => Single.IsNaN(p)).WithDefaultMessage(ErrorMessages.IsNaN);

        public static IValitRule<TObject, float?> IsNaN<TObject>(this IValitRule<TObject, float?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && Single.IsNaN(p.Value)).WithDefaultMessage(ErrorMessages.IsNaN);

        public static IValitRule<TObject, float?> Required<TObject>(this IValitRule<TObject, float?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue).WithDefaultMessage(ErrorMessages.Required);
    }
}
