using System;
using Valit.Errors;
using Valit.Extensions;

namespace Valit
{
    public static class ValitRuleFloatExtensions
    {
        public static IValitRule<TObject, float> IsGreaterThan<TObject>(this IValitRule<TObject, float> rule, float value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && !Single.IsNaN(value) && p.IsGreaterThan(value, epsilon)).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, float> IsGreaterThan<TObject>(this IValitRule<TObject, float> rule, float? value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Single.IsNaN(p) && !Single.IsNaN(value.Value) && p.IsGreaterThan(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, float?> IsGreaterThan<TObject>(this IValitRule<TObject, float?> rule, float value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value) && p.Value.IsGreaterThan(value, epsilon)).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, float?> IsGreaterThan<TObject>(this IValitRule<TObject, float?> rule, float? value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value.Value) && p.Value.IsGreaterThan(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, float> IsLessThan<TObject>(this IValitRule<TObject, float> rule, float value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && !Single.IsNaN(value) && p.IsLessThan(value, epsilon)).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, float> IsLessThan<TObject>(this IValitRule<TObject, float> rule, float? value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Single.IsNaN(p) && !Single.IsNaN(value.Value) && p.IsLessThan(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, float?> IsLessThan<TObject>(this IValitRule<TObject, float?> rule, float value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value) && p.Value.IsLessThan(value, epsilon)).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, float?> IsLessThan<TObject>(this IValitRule<TObject, float?> rule, float? value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value.Value) && p.Value.IsLessThan(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, float> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, float> rule, float value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && !Single.IsNaN(value) && p.IsGreaterOrEqualThan(value, epsilon)).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, float> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, float> rule, float? value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Single.IsNaN(p) && !Single.IsNaN(value.Value) && p.IsGreaterOrEqualThan(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, float?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, float?> rule, float value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value) && p.Value.IsGreaterOrEqualThan(value, epsilon)).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, float?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, float?> rule, float? value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value.Value) && p.Value.IsGreaterOrEqualThan(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, float> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, float> rule, float value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && !Single.IsNaN(value) && p.IsLessOrEqualThan(value, epsilon)).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, float> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, float> rule, float? value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Single.IsNaN(p) && !Single.IsNaN(value.Value) && p.IsLessOrEqualThan(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, float?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, float?> rule, float value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value) && p.Value.IsLessOrEqualThan(value, epsilon)).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, float?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, float?> rule, float? value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value.Value) && p.Value.IsLessOrEqualThan(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, float> IsEqualTo<TObject>(this IValitRule<TObject, float> rule, float value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && !Single.IsNaN(value) && p.IsEqual(value, epsilon)).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, float> IsEqualTo<TObject>(this IValitRule<TObject, float> rule, float? value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Single.IsNaN(p) && !Single.IsNaN(value.Value) && p.IsEqual(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, float?> IsEqualTo<TObject>(this IValitRule<TObject, float?> rule, float value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value) && p.Value.IsEqual(value, epsilon)).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, float?> IsEqualTo<TObject>(this IValitRule<TObject, float?> rule, float? value, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value.Value) && p.Value.IsEqual(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, float> IsPositive<TObject>(this IValitRule<TObject, float> rule, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && p > 0f).WithDefaultMessage(ErrorMessages.IsPositive);

        public static IValitRule<TObject, float?> IsPositive<TObject>(this IValitRule<TObject, float?> rule, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && p.Value > 0f).WithDefaultMessage(ErrorMessages.IsPositive);

        public static IValitRule<TObject, float> IsNegative<TObject>(this IValitRule<TObject, float> rule, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && p < 0f).WithDefaultMessage(ErrorMessages.IsNegative);

        public static IValitRule<TObject, float?> IsNegative<TObject>(this IValitRule<TObject, float?> rule, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && p.Value < 0f).WithDefaultMessage(ErrorMessages.IsNegative);

        public static IValitRule<TObject, float> IsNonZero<TObject>(this IValitRule<TObject, float> rule, float epsilon = .0f) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && p != 0f).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, float?> IsNonZero<TObject>(this IValitRule<TObject, float?> rule, float epsilon = .0f) where TObject : class
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
