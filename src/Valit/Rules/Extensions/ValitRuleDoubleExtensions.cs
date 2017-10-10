using System;

namespace Valit
{
    public static class ValitRuleDoubleExtensions
    {
        public static IValitRule<TObject, double> IsGreaterThan<TObject>(this IValitRule<TObject, double> rule, double value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => !Double.IsNaN(p) && !Double.IsNaN(value) && p > value);
        }

        public static IValitRule<TObject, double> IsGreaterThan<TObject>(this IValitRule<TObject, double> rule, double? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => value.HasValue && !Double.IsNaN(p) && !Double.IsNaN(value.Value) && p > value);
        }

        public static IValitRule<TObject, double?> IsGreaterThan<TObject>(this IValitRule<TObject, double?> rule, double value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value) && p > value);
        }

        public static IValitRule<TObject, double?> IsGreaterThan<TObject>(this IValitRule<TObject, double?> rule, double? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && value.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value.Value) && p > value);
        }

        public static IValitRule<TObject, double> IsLessThan<TObject>(this IValitRule<TObject, double> rule, double value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => !Double.IsNaN(p) && !Double.IsNaN(value) && value > p);
        }

        public static IValitRule<TObject, double> IsLessThan<TObject>(this IValitRule<TObject, double> rule, double? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => !Double.IsNaN(p) && !Double.IsNaN(value.Value) && value > p);
        }

        public static IValitRule<TObject, double?> IsLessThan<TObject>(this IValitRule<TObject, double?> rule, double value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value) && value > p);
        }

        public static IValitRule<TObject, double?> IsLessThan<TObject>(this IValitRule<TObject, double?> rule, double? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && value.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value.Value) && value > p);
        }

        public static IValitRule<TObject, double> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, double> rule, double value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => !Double.IsNaN(p) && !Double.IsNaN(value) && p >= value);
        }

        public static IValitRule<TObject, double> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, double> rule, double? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => value.HasValue && !Double.IsNaN(p) && !Double.IsNaN(value.Value) && p >= value);
        }

        public static IValitRule<TObject, double?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, double?> rule, double value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value) && p >= value);
        }

        public static IValitRule<TObject, double?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, double?> rule, double? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && value.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value.Value) && p >= value);
        }

        public static IValitRule<TObject, double> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, double> rule, double value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => !Double.IsNaN(p) && !Double.IsNaN(value) && p <= value);
        }

        public static IValitRule<TObject, double> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, double> rule, double? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => value.HasValue && !Double.IsNaN(p) && !Double.IsNaN(value.Value) && p <= value);
        }

        public static IValitRule<TObject, double?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, double?> rule, double value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value) && p <= value);
        }

        public static IValitRule<TObject, double?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, double?> rule, double? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && value.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value.Value) && p <= value);
        }

        public static IValitRule<TObject, double> IsEqualTo<TObject>(this IValitRule<TObject, double> rule, double value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => !Double.IsNaN(p) && !Double.IsNaN(value) && p == value);
        }

        public static IValitRule<TObject, double> IsEqualTo<TObject>(this IValitRule<TObject, double> rule, double? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => value.HasValue && !Double.IsNaN(p) && !Double.IsNaN(value.Value) && p == value);
        }

        public static IValitRule<TObject, double?> IsEqualTo<TObject>(this IValitRule<TObject, double?> rule, double value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value) && p == value);
        }

        public static IValitRule<TObject, double?> IsEqualTo<TObject>(this IValitRule<TObject, double?> rule, double? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && value.HasValue && !Double.IsNaN(p.Value) && !Double.IsNaN(value.Value) && p == value);
        }

        public static IValitRule<TObject, double> IsPositive<TObject>(this IValitRule<TObject, double> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => !Double.IsNaN(p) && p > 0d);
        }

        public static IValitRule<TObject, double?> IsPositive<TObject>(this IValitRule<TObject, double?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && !Double.IsNaN(p.Value) && p > 0d);
        }

        public static IValitRule<TObject, double> IsNegative<TObject>(this IValitRule<TObject, double> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => !Double.IsNaN(p) && p < 0d);
        }

        public static IValitRule<TObject, double?> IsNegative<TObject>(this IValitRule<TObject, double?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && !Double.IsNaN(p.Value) && p < 0d);
        }

        public static IValitRule<TObject, double> IsNonZero<TObject>(this IValitRule<TObject, double> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => !Double.IsNaN(p) && p != 0d);
        }

        public static IValitRule<TObject, double?> IsNonZero<TObject>(this IValitRule<TObject, double?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && !Double.IsNaN(p.Value) && p != 0d);
        }

        public static IValitRule<TObject, double> IsNumber<TObject>(this IValitRule<TObject, double> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => !Double.IsNaN(p));
        }

        public static IValitRule<TObject, double?> IsNumber<TObject>(this IValitRule<TObject, double?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && !Double.IsNaN(p.Value));
        }

        public static IValitRule<TObject, double> IsNaN<TObject>(this IValitRule<TObject, double> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => Double.IsNaN(p));
        }

        public static IValitRule<TObject, double?> IsNaN<TObject>(this IValitRule<TObject, double?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && Double.IsNaN(p.Value));
        }

        public static IValitRule<TObject, double?> Required<TObject>(this IValitRule<TObject, double?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue);
        }
    }
}