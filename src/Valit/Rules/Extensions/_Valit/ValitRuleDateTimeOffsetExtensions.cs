using System;

namespace Valit
{
    public static class ValitRuleDateTimeOffsetExtensions
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

        public static IValitRule<TObject, DateTimeOffset> IsAfterOrSameAs<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p >= dateTimeOffset);
        }

        public static IValitRule<TObject, DateTimeOffset> IsAfterOrSameAs<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset? dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => dateTimeOffset.HasValue && p >= dateTimeOffset.Value);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsAfterOrSameAs<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value >= dateTimeOffset);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsAfterOrSameAs<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset? dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && dateTimeOffset.HasValue && p.Value >= dateTimeOffset.Value);
        }

        public static IValitRule<TObject, DateTimeOffset> IsBeforeOrSameAs<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p <= dateTimeOffset);
        }

        public static IValitRule<TObject, DateTimeOffset> IsBeforeOrSameAs<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset? dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => dateTimeOffset.HasValue && p <= dateTimeOffset.Value);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsBeforeOrSameAs<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value <= dateTimeOffset);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsBeforeOrSameAs<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset? dateTimeOffset) where TObject : class
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

        public static IValitRule<TObject, DateTimeOffset> IsAfterOrSameAsNow<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p >= DateTimeOffset.Now);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsAfterOrSameAsNow<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value >= DateTimeOffset.Now);
        }

        public static IValitRule<TObject, DateTimeOffset> IsBeforeOrSameAsNow<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p <= DateTimeOffset.Now);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsBeforeOrSameAsNow<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value <= DateTimeOffset.Now);
        }

        public static IValitRule<TObject, DateTimeOffset> IsAfterOrSameAsUtcNow<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p >= DateTimeOffset.UtcNow);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsAfterOrSameAsUtcNow<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value >= DateTimeOffset.UtcNow);
        }

        public static IValitRule<TObject, DateTimeOffset> IsBeforeOrSameAsUtcNow<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p <= DateTimeOffset.UtcNow);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsBeforeOrSameAsUtcNow<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value <= DateTimeOffset.UtcNow);
        }

        public static IValitRule<TObject, DateTimeOffset> IsSameAs<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p == dateTimeOffset);
        }

        public static IValitRule<TObject, DateTimeOffset> IsSameAs<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset? dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => dateTimeOffset.HasValue && p == dateTimeOffset.Value);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsSameAs<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value == dateTimeOffset);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsSameAs<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset? dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && dateTimeOffset.HasValue && p.Value == dateTimeOffset.Value);
        }

        public static IValitRule<TObject, DateTimeOffset> IsAfterToday<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.Date > DateTime.Today);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsAfterToday<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value.Date > DateTime.Today);
        }

        public static IValitRule<TObject, DateTimeOffset> IsBeforeToday<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.Date < DateTime.Today);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsBeforeToday<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value.Date < DateTime.Today);
        }

        public static IValitRule<TObject, DateTimeOffset> IsAfterUtcToday<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.Date > DateTimeOffset.UtcNow.Date);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsAfterUtcToday<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value.Date > DateTimeOffset.UtcNow.Date);
        }

        public static IValitRule<TObject, DateTimeOffset> IsBeforeUtcToday<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.Date < DateTimeOffset.UtcNow.Date);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsBeforeUtcToday<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value.Date < DateTimeOffset.UtcNow.Date);
        }

        public static IValitRule<TObject, DateTimeOffset> IsAfterOrSameAsToday<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.Date >= DateTime.Today);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsAfterOrSameAsToday<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value.Date >= DateTime.Today);
        }

        public static IValitRule<TObject, DateTimeOffset> IsBeforeOrSameAsToday<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.Date <= DateTime.Today);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsBeforeOrSameAsToday<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value.Date <= DateTime.Today);
        }

        public static IValitRule<TObject, DateTimeOffset> IsAfterOrSameAsUtcToday<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.Date >= DateTime.UtcNow.Date);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsAfterOrSameAsUtcToday<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value.Date >= DateTime.UtcNow.Date);
        }

        public static IValitRule<TObject, DateTimeOffset> IsBeforeOrSameAsUtcToday<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.Date <= DateTime.UtcNow.Date);
        }

        public static IValitRule<TObject, DateTimeOffset?> IsBeforeOrSameAsUtcToday<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value.Date <= DateTime.UtcNow.Date);
        }

        public static IValitRule<TObject, DateTimeOffset> IsSameDay<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset? dateTimeOffset) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => dateTimeOffset.HasValue && p.Date == dateTimeOffset.Value.Date);
        }

        public static IValitRule<TObject, DateTimeOffset?> Required<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue);
        }
    }
}