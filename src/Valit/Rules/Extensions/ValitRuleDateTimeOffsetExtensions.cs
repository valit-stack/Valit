using System;

namespace Valit
{
    public static class ValitRuleDateTimeOffsetOffsetExtensions
    {
        public static IValitRule<TObject, DateTimeOffset> IsAfter<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p > dateTimeOffset);
        }

        public static IValitRule<TObject, DateTimeOffset> IsAfter<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset? dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => dateTimeOffset.HasValue && p > dateTimeOffset.Value);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsAfter<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value > dateTimeOffset);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsAfter<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset? dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && dateTimeOffset.HasValue && p.Value > dateTimeOffset.Value);
        }

        public static IValitRule<TObject, DateTimeOffset> IsBefore<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p < dateTimeOffset);
        }

        public static IValitRule<TObject, DateTimeOffset> IsBefore<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset? dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => dateTimeOffset.HasValue && p < dateTimeOffset.Value);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsBefore<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value < dateTimeOffset);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsBefore<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset? dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && dateTimeOffset.HasValue && p.Value < dateTimeOffset.Value);
        }

        public static IValitRule<TObject, DateTimeOffset> IsAfterOrEqualTo<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p >= dateTimeOffset);
        }

        public static IValitRule<TObject, DateTimeOffset> IsAfterOrEqualTo<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset? dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => dateTimeOffset.HasValue && p >= dateTimeOffset.Value);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsAfterOrEqualTo<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value >= dateTimeOffset);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsAfterOrEqualTo<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset? dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && dateTimeOffset.HasValue && p.Value >= dateTimeOffset.Value);
        }

        public static IValitRule<TObject, DateTimeOffset> IsBeforeOrEqualTo<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p <= dateTimeOffset);
        }

        public static IValitRule<TObject, DateTimeOffset> IsBeforeOrEqualTo<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset? dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => dateTimeOffset.HasValue && p <= dateTimeOffset.Value);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsBeforeOrEqualTo<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value <= dateTimeOffset);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsBeforeOrEqualTo<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset? dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && dateTimeOffset.HasValue && p.Value <= dateTimeOffset.Value);
        }

        public static IValitRule<TObject, DateTimeOffset> IsAfterNow<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p > DateTimeOffset.Now);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsAfterNow<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value > DateTimeOffset.Now);
        }

        public static IValitRule<TObject, DateTimeOffset> IsBeforeNow<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p < DateTimeOffset.Now);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsBeforeNow<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value < DateTimeOffset.Now);
        }

        public static IValitRule<TObject, DateTimeOffset> IsAfterUtcNow<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p > DateTimeOffset.UtcNow);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsAfterUtcNow<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value > DateTimeOffset.UtcNow);
        }

        public static IValitRule<TObject, DateTimeOffset> IsBeforeUtcNow<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p < DateTimeOffset.UtcNow);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsBeforeUtcNow<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value < DateTimeOffset.UtcNow);
        }

        public static IValitRule<TObject, DateTimeOffset> IsAfterOrEqualToNow<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p >= DateTimeOffset.Now);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsAfterOrEqualToNow<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value >= DateTimeOffset.Now);
        }

        public static IValitRule<TObject, DateTimeOffset> IsBeforeOrEqualToNow<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p <= DateTimeOffset.Now);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsBeforeOrEqualToNow<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value <= DateTimeOffset.Now);
        }

        public static IValitRule<TObject, DateTimeOffset> IsAfterOrEqualToUtcNow<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p >= DateTimeOffset.UtcNow);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsAfterOrEqualToUtcNow<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value >= DateTimeOffset.UtcNow);
        }

        public static IValitRule<TObject, DateTimeOffset> IsBeforeOrEqualToUtcNow<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p <= DateTimeOffset.UtcNow);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsBeforeOrEqualToUtcNow<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value <= DateTimeOffset.UtcNow);
        }

        public static IValitRule<TObject, DateTimeOffset> IsEqualTo<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p == dateTimeOffset);
        }

        public static IValitRule<TObject, DateTimeOffset> IsEqualTo<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset? dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => dateTimeOffset.HasValue && p == dateTimeOffset.Value);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsEqualTo<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value == dateTimeOffset);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsEqualTo<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset? dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && dateTimeOffset.HasValue && p.Value == dateTimeOffset.Value);
        }

        public static IValitRule<TObject, DateTimeOffset?> Required<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue);
        }
    }
}