using System;

namespace Valit
{
    public static class ValitRuleDateTimeExtensions
    {
        public static IValitRule<TObject, DateTime> IsAfter<TObject>(this IValitRule<TObject, DateTime> rule, DateTime datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p > datetime);
        }

        public static IValitRule<TObject, DateTime> IsAfter<TObject>(this IValitRule<TObject, DateTime> rule, DateTime? datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => datetime.HasValue && p > datetime.Value);
        }

        public static IValitRule<TObject, DateTime?> IsAfter<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value > datetime);
        }

        public static IValitRule<TObject, DateTime?> IsAfter<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime? datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && datetime.HasValue && p.Value > datetime.Value);
        }

        public static IValitRule<TObject, DateTime> IsBefore<TObject>(this IValitRule<TObject, DateTime> rule, DateTime datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p < datetime);
        }

        public static IValitRule<TObject, DateTime> IsBefore<TObject>(this IValitRule<TObject, DateTime> rule, DateTime? datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => datetime.HasValue && p < datetime.Value);
        }

        public static IValitRule<TObject, DateTime?> IsBefore<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value < datetime);
        }

        public static IValitRule<TObject, DateTime?> IsBefore<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime? datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && datetime.HasValue && p.Value < datetime.Value);
        }

        public static IValitRule<TObject, DateTime> IsAfterOrSameAs<TObject>(this IValitRule<TObject, DateTime> rule, DateTime datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p >= datetime);
        }

        public static IValitRule<TObject, DateTime> IsAfterOrSameAs<TObject>(this IValitRule<TObject, DateTime> rule, DateTime? datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => datetime.HasValue && p >= datetime.Value);
        }

        public static IValitRule<TObject, DateTime?> IsAfterOrSameAs<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value >= datetime);
        }

        public static IValitRule<TObject, DateTime?> IsAfterOrSameAs<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime? datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && datetime.HasValue && p.Value >= datetime.Value);
        }

        public static IValitRule<TObject, DateTime> IsBeforeOrSameAs<TObject>(this IValitRule<TObject, DateTime> rule, DateTime datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p <= datetime);
        }

        public static IValitRule<TObject, DateTime> IsBeforeOrSameAs<TObject>(this IValitRule<TObject, DateTime> rule, DateTime? datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => datetime.HasValue && p <= datetime.Value);
        }

        public static IValitRule<TObject, DateTime?> IsBeforeOrSameAs<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value <= datetime);
        }

        public static IValitRule<TObject, DateTime?> IsBeforeOrSameAs<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime? datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && datetime.HasValue && p.Value <= datetime.Value);
        }

        public static IValitRule<TObject, DateTime> IsAfterNow<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p > DateTime.Now);
        }

        public static IValitRule<TObject, DateTime?> IsAfterNow<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value > DateTime.Now);
        }

        public static IValitRule<TObject, DateTime> IsBeforeNow<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p < DateTime.Now);
        }

        public static IValitRule<TObject, DateTime?> IsBeforeNow<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value < DateTime.Now);
        }

        public static IValitRule<TObject, DateTime> IsAfterUtcNow<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p > DateTime.UtcNow);
        }

        public static IValitRule<TObject, DateTime?> IsAfterUtcNow<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value > DateTime.UtcNow);
        }

        public static IValitRule<TObject, DateTime> IsBeforeUtcNow<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p < DateTime.UtcNow);
        }

        public static IValitRule<TObject, DateTime?> IsBeforeUtcNow<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value < DateTime.UtcNow);
        }

        public static IValitRule<TObject, DateTime> IsAfterOrSameAsNow<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p >= DateTime.Now);
        }

        public static IValitRule<TObject, DateTime?> IsAfterOrSameAsNow<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value >= DateTime.Now);
        }

        public static IValitRule<TObject, DateTime> IsBeforeOrSameAsNow<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p <= DateTime.Now);
        }

        public static IValitRule<TObject, DateTime?> IsBeforeOrSameAsNow<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value <= DateTime.Now);
        }

        public static IValitRule<TObject, DateTime> IsAfterOrSameAsUtcNow<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p >= DateTime.UtcNow);
        }

        public static IValitRule<TObject, DateTime?> IsAfterOrSameAsUtcNow<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value >= DateTime.UtcNow);
        }

        public static IValitRule<TObject, DateTime> IsBeforeOrSameAsUtcNow<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p <= DateTime.UtcNow);
        }

        public static IValitRule<TObject, DateTime?> IsBeforeOrSameAsUtcNow<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value <= DateTime.UtcNow);
        }
    
        public static IValitRule<TObject, DateTime> IsAfterToday<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.Date > DateTime.Today);
        }

        public static IValitRule<TObject, DateTime?> IsAfterToday<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value.Date > DateTime.Today);
        }

        public static IValitRule<TObject, DateTime> IsBeforeToday<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.Date < DateTime.Today);
        }

        public static IValitRule<TObject, DateTime?> IsBeforeToday<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value.Date < DateTime.Today);
        }

        public static IValitRule<TObject, DateTime> IsAfterUtcToday<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.Date > DateTime.UtcNow.Date);
        }

        public static IValitRule<TObject, DateTime?> IsAfterUtcToday<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value.Date > DateTime.UtcNow.Date);
        }

        public static IValitRule<TObject, DateTime> IsBeforeUtcToday<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.Date < DateTime.UtcNow.Date);
        }

        public static IValitRule<TObject, DateTime?> IsBeforeUtcToday<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value.Date < DateTime.UtcNow.Date);
        }

        public static IValitRule<TObject, DateTime> IsAfterOrSameAsToday<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.Date >= DateTime.Today);
        }

        public static IValitRule<TObject, DateTime?> IsAfterOrSameAsToday<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value.Date >= DateTime.Today);
        }

        public static IValitRule<TObject, DateTime> IsBeforeOrSameAsToday<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.Date <= DateTime.Today);
        }

        public static IValitRule<TObject, DateTime?> IsBeforeOrSameAsToday<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value.Date <= DateTime.Today);
        }

        public static IValitRule<TObject, DateTime> IsAfterOrSameAsUtcToday<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.Date >= DateTime.UtcNow.Date);
        }

        public static IValitRule<TObject, DateTime?> IsAfterOrSameAsUtcToday<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value.Date >= DateTime.UtcNow.Date);
        }

        public static IValitRule<TObject, DateTime> IsBeforeOrSameAsUtcToday<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.Date <= DateTime.UtcNow.Date);
        }

        public static IValitRule<TObject, DateTime?> IsBeforeOrSameAsUtcToday<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value.Date <= DateTime.UtcNow.Date);
        }       

        public static IValitRule<TObject, DateTime> IsSameDay<TObject>(this IValitRule<TObject, DateTime> rule, DateTime? datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => datetime.HasValue && p.Date == datetime.Value.Date);
        }

        public static IValitRule<TObject, DateTime> IsSameAs<TObject>(this IValitRule<TObject, DateTime> rule, DateTime? datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => datetime.HasValue && p == datetime.Value);
        }

        public static IValitRule<TObject, DateTime?> IsSameAs<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value == datetime);
        }

        public static IValitRule<TObject, DateTime?> IsSameAs<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime? datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && datetime.HasValue && p.Value == datetime.Value);
        }

        public static IValitRule<TObject, DateTime> IsSameAs<TObject>(this IValitRule<TObject, DateTime> rule, DateTime datetime) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p == datetime);
        }

        public static IValitRule<TObject, DateTime?> Required<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue);
        }
    }
}