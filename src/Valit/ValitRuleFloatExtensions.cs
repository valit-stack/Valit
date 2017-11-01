using System;

namespace Valit
{
    public static class ValitRuleFloatExtensions
    {
        public static IValitRule<TObject, float> IsGreaterThan<TObject>(this IValitRule<TObject, float> rule, float value) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && !Single.IsNaN(value) && p > value);

        public static IValitRule<TObject, float> IsGreaterThan<TObject>(this IValitRule<TObject, float> rule, float? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Single.IsNaN(p) && !Single.IsNaN(value.Value) && p > value.Value);

        public static IValitRule<TObject, float?> IsGreaterThan<TObject>(this IValitRule<TObject, float?> rule, float value) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value) && p.Value > value);

        public static IValitRule<TObject, float?> IsGreaterThan<TObject>(this IValitRule<TObject, float?> rule, float? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value.Value) && p.Value > value.Value);

        public static IValitRule<TObject, float> IsLessThan<TObject>(this IValitRule<TObject, float> rule, float value) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && !Single.IsNaN(value) && value > p);

        public static IValitRule<TObject, float> IsLessThan<TObject>(this IValitRule<TObject, float> rule, float? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Single.IsNaN(p) && !Single.IsNaN(value.Value) && value.Value > p);

        public static IValitRule<TObject, float?> IsLessThan<TObject>(this IValitRule<TObject, float?> rule, float value) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value) && value > p.Value);

        public static IValitRule<TObject, float?> IsLessThan<TObject>(this IValitRule<TObject, float?> rule, float? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value.Value) && value.Value > p.Value);

        public static IValitRule<TObject, float> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, float> rule, float value) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && !Single.IsNaN(value) && p >= value);

        public static IValitRule<TObject, float> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, float> rule, float? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Single.IsNaN(p) && !Single.IsNaN(value.Value) && p >= value.Value);

        public static IValitRule<TObject, float?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, float?> rule, float value) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value) && p.Value >= value);

        public static IValitRule<TObject, float?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, float?> rule, float? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value.Value) && p.Value >= value.Value);

        public static IValitRule<TObject, float> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, float> rule, float value) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && !Single.IsNaN(value) && p <= value);

        public static IValitRule<TObject, float> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, float> rule, float? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Single.IsNaN(p) && !Single.IsNaN(value.Value) && p <= value.Value);

        public static IValitRule<TObject, float?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, float?> rule, float value) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value) && p.Value <= value);

        public static IValitRule<TObject, float?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, float?> rule, float? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value.Value) && p.Value <= value.Value);

        public static IValitRule<TObject, float> IsEqualTo<TObject>(this IValitRule<TObject, float> rule, float value) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && !Single.IsNaN(value) && p == value);

        public static IValitRule<TObject, float> IsEqualTo<TObject>(this IValitRule<TObject, float> rule, float? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && !Single.IsNaN(p) && !Single.IsNaN(value.Value) && p == value.Value);

        public static IValitRule<TObject, float?> IsEqualTo<TObject>(this IValitRule<TObject, float?> rule, float value) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value) && p.Value == value);

        public static IValitRule<TObject, float?> IsEqualTo<TObject>(this IValitRule<TObject, float?> rule, float? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && !Single.IsNaN(p.Value) && !Single.IsNaN(value.Value) && p.Value == value.Value);

        public static IValitRule<TObject, float> IsPositive<TObject>(this IValitRule<TObject, float> rule) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && p > 0f);

        public static IValitRule<TObject, float?> IsPositive<TObject>(this IValitRule<TObject, float?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && p.Value > 0f);

        public static IValitRule<TObject, float> IsNegative<TObject>(this IValitRule<TObject, float> rule) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && p < 0f);

        public static IValitRule<TObject, float?> IsNegative<TObject>(this IValitRule<TObject, float?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && p.Value < 0f);

        public static IValitRule<TObject, float> IsNonZero<TObject>(this IValitRule<TObject, float> rule) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p) && p != 0f);

        public static IValitRule<TObject, float?> IsNonZero<TObject>(this IValitRule<TObject, float?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value) && p.Value != 0f);

        public static IValitRule<TObject, float> IsNumber<TObject>(this IValitRule<TObject, float> rule) where TObject : class
            => rule.Satisfies(p => !Single.IsNaN(p));

        public static IValitRule<TObject, float?> IsNumber<TObject>(this IValitRule<TObject, float?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && !Single.IsNaN(p.Value));

        public static IValitRule<TObject, float> IsNaN<TObject>(this IValitRule<TObject, float> rule) where TObject : class
            => rule.Satisfies(p => Single.IsNaN(p));

        public static IValitRule<TObject, float?> IsNaN<TObject>(this IValitRule<TObject, float?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && Single.IsNaN(p.Value));

        public static IValitRule<TObject, float?> Required<TObject>(this IValitRule<TObject, float?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue);
    }
}