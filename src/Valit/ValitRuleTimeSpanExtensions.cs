using System;

namespace Valit
{
    public static class ValitRuleTimeSpanExtensions
    {
        public static IValitRule<TObject, TimeSpan> IsGreaterThan<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan TimeSpan) where TObject : class
            => rule.Satisfies(p => p > TimeSpan);

        public static IValitRule<TObject, TimeSpan> IsGreaterThan<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan? TimeSpan) where TObject : class
            => rule.Satisfies(p => TimeSpan.HasValue && p > TimeSpan.Value);

        public static IValitRule<TObject, TimeSpan?> IsGreaterThan<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan TimeSpan) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > TimeSpan);

        public static IValitRule<TObject, TimeSpan?> IsGreaterThan<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan? TimeSpan) where TObject : class
            => rule.Satisfies(p => p.HasValue && TimeSpan.HasValue && p.Value > TimeSpan.Value);

        public static IValitRule<TObject, TimeSpan> IsLessThan<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan TimeSpan) where TObject : class
            => rule.Satisfies(p => p < TimeSpan);

        public static IValitRule<TObject, TimeSpan> IsLessThan<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan? TimeSpan) where TObject : class
            => rule.Satisfies(p => TimeSpan.HasValue && p < TimeSpan.Value);

        public static IValitRule<TObject, TimeSpan?> IsLessThan<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan TimeSpan) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < TimeSpan);

        public static IValitRule<TObject, TimeSpan?> IsLessThan<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan? TimeSpan) where TObject : class
            => rule.Satisfies(p => p.HasValue && TimeSpan.HasValue && p.Value < TimeSpan.Value);

        public static IValitRule<TObject, TimeSpan> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan TimeSpan) where TObject : class
            => rule.Satisfies(p => p >= TimeSpan);

        public static IValitRule<TObject, TimeSpan> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan? TimeSpan) where TObject : class
            => rule.Satisfies(p => TimeSpan.HasValue && p >= TimeSpan.Value);

        public static IValitRule<TObject, TimeSpan?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan TimeSpan) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value >= TimeSpan);

        public static IValitRule<TObject, TimeSpan?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan? TimeSpan) where TObject : class
            => rule.Satisfies(p => p.HasValue && TimeSpan.HasValue && p.Value >= TimeSpan.Value);

        public static IValitRule<TObject, TimeSpan> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan TimeSpan) where TObject : class
            => rule.Satisfies(p => p <= TimeSpan);

        public static IValitRule<TObject, TimeSpan> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan? TimeSpan) where TObject : class
            => rule.Satisfies(p => TimeSpan.HasValue && p <= TimeSpan.Value);

        public static IValitRule<TObject, TimeSpan?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan TimeSpan) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value <= TimeSpan);

        public static IValitRule<TObject, TimeSpan?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan? TimeSpan) where TObject : class
            => rule.Satisfies(p => p.HasValue && TimeSpan.HasValue && p.Value <= TimeSpan.Value);

        public static IValitRule<TObject, TimeSpan> IsEqualTo<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan TimeSpan) where TObject : class
            => rule.Satisfies(p => p == TimeSpan);

        public static IValitRule<TObject, TimeSpan> IsEqualTo<TObject>(this IValitRule<TObject, TimeSpan> rule, TimeSpan? TimeSpan) where TObject : class
            => rule.Satisfies(p => TimeSpan.HasValue && p == TimeSpan.Value);

        public static IValitRule<TObject, TimeSpan?> IsEqualTo<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan TimeSpan) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value == TimeSpan);

        public static IValitRule<TObject, TimeSpan?> IsEqualTo<TObject>(this IValitRule<TObject, TimeSpan?> rule, TimeSpan? TimeSpan) where TObject : class
            => rule.Satisfies(p => p.HasValue && TimeSpan.HasValue && p.Value == TimeSpan.Value);

        public static IValitRule<TObject, TimeSpan> IsNonZero<TObject>(this IValitRule<TObject, TimeSpan> rule) where TObject : class
            => rule.Satisfies(p => p != TimeSpan.Zero);

        public static IValitRule<TObject, TimeSpan?> IsNonZero<TObject>(this IValitRule<TObject, TimeSpan?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value != TimeSpan.Zero);

        public static IValitRule<TObject, TimeSpan?> Required<TObject>(this IValitRule<TObject, TimeSpan?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue);
    }
}
