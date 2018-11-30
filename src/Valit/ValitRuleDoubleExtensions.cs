using System;
using Valit.Errors;
using Valit.Extensions;

namespace Valit
{
    public static class ValitRuleDoubleExtensions
    {
        public static IValitRule<TObject, double> IsGreaterThan<TObject>(this IValitRule<TObject, double> rule, double value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => !Double.IsNaN(p) && !Double.IsNaN(value) && p.IsGreaterThan(value, epsilon)).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, double> IsGreaterThan<TObject>(this IValitRule<TObject, double> rule, double? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Double.IsNaN(p) && !Double.IsNaN(value.Value) && p.IsGreaterThan(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, double?> IsGreaterThan<TObject>(this IValitRule<TObject, double?> rule, double value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value) && p.Value.IsGreaterThan(value, epsilon)).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, double?> IsGreaterThan<TObject>(this IValitRule<TObject, double?> rule, double? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value.Value) && p.Value.IsGreaterThan(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, double> IsLessThan<TObject>(this IValitRule<TObject, double> rule, double value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => !Double.IsNaN(p) && !Double.IsNaN(value) && p.IsLessThan(value, epsilon)).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, double> IsLessThan<TObject>(this IValitRule<TObject, double> rule, double? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Double.IsNaN(p) && !Double.IsNaN(value.Value) && p.IsLessThan(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, double?> IsLessThan<TObject>(this IValitRule<TObject, double?> rule, double value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value) && p.Value.IsLessThan(value, epsilon)).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, double?> IsLessThan<TObject>(this IValitRule<TObject, double?> rule, double? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value.Value) && p.Value.IsLessThan(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, double> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, double> rule, double value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => !Double.IsNaN(p) && !Double.IsNaN(value) && p.IsGreaterOrEqualThan(value, epsilon)).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, double> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, double> rule, double? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Double.IsNaN(p) && !Double.IsNaN(value.Value) &&  p.IsGreaterOrEqualThan(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, double?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, double?> rule, double value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value) && p.Value.IsGreaterOrEqualThan(value, epsilon)).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, double?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, double?> rule, double? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value.Value) && p.Value.IsGreaterOrEqualThan(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, double> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, double> rule, double value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => !Double.IsNaN(p) && !Double.IsNaN(value) && p.IsLessOrEqualThan(value, epsilon)).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, double> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, double> rule, double? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Double.IsNaN(p) && !Double.IsNaN(value.Value) && p.IsLessOrEqualThan(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, double?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, double?> rule, double value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value) && p.Value.IsLessOrEqualThan(value, epsilon)).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, double?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, double?> rule, double? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value.Value) && p.Value.IsLessOrEqualThan(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, double> IsEqualTo<TObject>(this IValitRule<TObject, double> rule, double value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => !Double.IsNaN(p) && !Double.IsNaN(value) && p.IsEqual(value, epsilon)).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, double> IsEqualTo<TObject>(this IValitRule<TObject, double> rule, double? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Double.IsNaN(p) && !Double.IsNaN(value.Value) && p.IsEqual(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, double?> IsEqualTo<TObject>(this IValitRule<TObject, double?> rule, double value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value) && p.Value.IsEqual(value, epsilon)).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, double?> IsEqualTo<TObject>(this IValitRule<TObject, double?> rule, double? value, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value.Value) && p.Value.IsEqual(value.Value, epsilon)).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, double> IsPositive<TObject>(this IValitRule<TObject, double> rule, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => !Double.IsNaN(p) && p.IsGreaterThan(0d, epsilon)).WithDefaultMessage(ErrorMessages.IsPositive);

        public static IValitRule<TObject, double?> IsPositive<TObject>(this IValitRule<TObject, double?> rule, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Double.IsNaN(p.Value) && p.Value.IsGreaterThan(0d, epsilon)).WithDefaultMessage(ErrorMessages.IsPositive);

        public static IValitRule<TObject, double> IsNegative<TObject>(this IValitRule<TObject, double> rule, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => !Double.IsNaN(p) && p.IsLessThan(0d, epsilon)).WithDefaultMessage(ErrorMessages.IsNegative);

        public static IValitRule<TObject, double?> IsNegative<TObject>(this IValitRule<TObject, double?> rule, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Double.IsNaN(p.Value) && p.Value.IsLessThan(0d, epsilon)).WithDefaultMessage(ErrorMessages.IsNegative);

        public static IValitRule<TObject, double> IsNonZero<TObject>(this IValitRule<TObject, double> rule, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => !Double.IsNaN(p) && p.IsNotEqual(0d, epsilon)).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, double?> IsNonZero<TObject>(this IValitRule<TObject, double?> rule, double epsilon = .0d) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Double.IsNaN(p.Value) && p.Value.IsNotEqual(0d, epsilon)).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, double> IsNumber<TObject>(this IValitRule<TObject, double> rule) where TObject : class
            => rule.Satisfies(p => !Double.IsNaN(p)).WithDefaultMessage(ErrorMessages.IsNumber);

        public static IValitRule<TObject, double?> IsNumber<TObject>(this IValitRule<TObject, double?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Double.IsNaN(p.Value)).WithDefaultMessage(ErrorMessages.IsNumber);

        public static IValitRule<TObject, double> IsNaN<TObject>(this IValitRule<TObject, double> rule) where TObject : class
            => rule.Satisfies(p => Double.IsNaN(p)).WithDefaultMessage(ErrorMessages.IsNaN);

        public static IValitRule<TObject, double?> IsNaN<TObject>(this IValitRule<TObject, double?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && Double.IsNaN(p.Value)).WithDefaultMessage(ErrorMessages.IsNaN);

        public static IValitRule<TObject, double?> Required<TObject>(this IValitRule<TObject, double?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue).WithDefaultMessage(ErrorMessages.Required);
    }
}
