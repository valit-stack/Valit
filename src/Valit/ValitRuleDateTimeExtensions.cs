using System;
using Valit.Errors;

namespace Valit
{
    public static class ValitRuleDateTimeExtensions
    {
        public static IValitRule<TObject, DateTime> IsAfter<TObject>(this IValitRule<TObject, DateTime> rule, DateTime datetime) where TObject : class
            => rule.Satisfies(p => p > datetime).WithDefaultMessage(ErrorMessages.IsAfter, datetime);

        public static IValitRule<TObject, DateTime> IsAfter<TObject>(this IValitRule<TObject, DateTime> rule, DateTime? datetime) where TObject : class
            => rule.Satisfies(p => datetime.HasValue && p > datetime.Value).WithDefaultMessage(ErrorMessages.IsAfter, datetime);

        public static IValitRule<TObject, DateTime?> IsAfter<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime datetime) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > datetime).WithDefaultMessage(ErrorMessages.IsAfter, datetime);

        public static IValitRule<TObject, DateTime?> IsAfter<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime? datetime) where TObject : class
            => rule.Satisfies(p => p.HasValue && datetime.HasValue && p.Value > datetime.Value).WithDefaultMessage(ErrorMessages.IsAfter, datetime);

        public static IValitRule<TObject, DateTime> IsBefore<TObject>(this IValitRule<TObject, DateTime> rule, DateTime datetime) where TObject : class
            => rule.Satisfies(p => p < datetime).WithDefaultMessage(ErrorMessages.IsBefore, datetime);

        public static IValitRule<TObject, DateTime> IsBefore<TObject>(this IValitRule<TObject, DateTime> rule, DateTime? datetime) where TObject : class
            => rule.Satisfies(p => datetime.HasValue && p < datetime.Value).WithDefaultMessage(ErrorMessages.IsBefore, datetime);

        public static IValitRule<TObject, DateTime?> IsBefore<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime datetime) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < datetime).WithDefaultMessage(ErrorMessages.IsBefore, datetime);

        public static IValitRule<TObject, DateTime?> IsBefore<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime? datetime) where TObject : class
            => rule.Satisfies(p => p.HasValue && datetime.HasValue && p.Value < datetime.Value).WithDefaultMessage(ErrorMessages.IsBefore, datetime);

        public static IValitRule<TObject, DateTime> IsAfterOrSameAs<TObject>(this IValitRule<TObject, DateTime> rule, DateTime datetime) where TObject : class
            => rule.Satisfies(p => p >= datetime).WithDefaultMessage(ErrorMessages.IsAfterOrSameAs, datetime);

        public static IValitRule<TObject, DateTime> IsAfterOrSameAs<TObject>(this IValitRule<TObject, DateTime> rule, DateTime? datetime) where TObject : class
            => rule.Satisfies(p => datetime.HasValue && p >= datetime.Value).WithDefaultMessage(ErrorMessages.IsAfterOrSameAs, datetime);

        public static IValitRule<TObject, DateTime?> IsAfterOrSameAs<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime datetime) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value >= datetime).WithDefaultMessage(ErrorMessages.IsAfterOrSameAs, datetime);

        public static IValitRule<TObject, DateTime?> IsAfterOrSameAs<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime? datetime) where TObject : class
            => rule.Satisfies(p => p.HasValue && datetime.HasValue && p.Value >= datetime.Value).WithDefaultMessage(ErrorMessages.IsAfterOrSameAs, datetime);

        public static IValitRule<TObject, DateTime> IsBeforeOrSameAs<TObject>(this IValitRule<TObject, DateTime> rule, DateTime datetime) where TObject : class
            => rule.Satisfies(p => p <= datetime).WithDefaultMessage(ErrorMessages.IsBeforeOrSameAs, datetime);

        public static IValitRule<TObject, DateTime> IsBeforeOrSameAs<TObject>(this IValitRule<TObject, DateTime> rule, DateTime? datetime) where TObject : class
            => rule.Satisfies(p => datetime.HasValue && p <= datetime.Value).WithDefaultMessage(ErrorMessages.IsBeforeOrSameAs, datetime);

        public static IValitRule<TObject, DateTime?> IsBeforeOrSameAs<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime datetime) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value <= datetime).WithDefaultMessage(ErrorMessages.IsBeforeOrSameAs, datetime);

        public static IValitRule<TObject, DateTime?> IsBeforeOrSameAs<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime? datetime) where TObject : class
            => rule.Satisfies(p => p.HasValue && datetime.HasValue && p.Value <= datetime.Value).WithDefaultMessage(ErrorMessages.IsBeforeOrSameAs, datetime);

        public static IValitRule<TObject, DateTime> IsAfterNow<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
            => rule.Satisfies(p => p > DateTime.Now).WithDefaultMessage(ErrorMessages.IsAfter, DateTime.Now);

        public static IValitRule<TObject, DateTime?> IsAfterNow<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > DateTime.Now).WithDefaultMessage(ErrorMessages.IsAfter, DateTime.Now);

        public static IValitRule<TObject, DateTime> IsBeforeNow<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
            => rule.Satisfies(p => p < DateTime.Now).WithDefaultMessage(ErrorMessages.IsBefore, DateTime.Now);

        public static IValitRule<TObject, DateTime?> IsBeforeNow<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < DateTime.Now).WithDefaultMessage(ErrorMessages.IsBefore, DateTime.Now);

        public static IValitRule<TObject, DateTime> IsAfterUtcNow<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
            => rule.Satisfies(p => p > DateTime.UtcNow).WithDefaultMessage(ErrorMessages.IsAfter, DateTime.UtcNow);

        public static IValitRule<TObject, DateTime?> IsAfterUtcNow<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > DateTime.UtcNow).WithDefaultMessage(ErrorMessages.IsAfter, DateTime.UtcNow);

        public static IValitRule<TObject, DateTime> IsBeforeUtcNow<TObject>(this IValitRule<TObject, DateTime> rule) where TObject : class
            => rule.Satisfies(p => p < DateTime.UtcNow).WithDefaultMessage(ErrorMessages.IsBefore, DateTime.UtcNow);

        public static IValitRule<TObject, DateTime?> IsBeforeUtcNow<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < DateTime.UtcNow).WithDefaultMessage(ErrorMessages.IsBefore, DateTime.UtcNow);

        public static IValitRule<TObject, DateTime> IsSameAs<TObject>(this IValitRule<TObject, DateTime> rule, DateTime datetime) where TObject : class
            => rule.Satisfies(p => p == datetime).WithDefaultMessage(ErrorMessages.IsSameAs, datetime);

        public static IValitRule<TObject, DateTime> IsSameAs<TObject>(this IValitRule<TObject, DateTime> rule, DateTime? datetime) where TObject : class
            => rule.Satisfies(p => datetime.HasValue && p == datetime.Value).WithDefaultMessage(ErrorMessages.IsSameAs, datetime);

        public static IValitRule<TObject, DateTime?> IsSameAs<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime datetime) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value == datetime).WithDefaultMessage(ErrorMessages.IsSameAs, datetime);

        public static IValitRule<TObject, DateTime?> IsSameAs<TObject>(this IValitRule<TObject, DateTime?> rule, DateTime? datetime) where TObject : class
            => rule.Satisfies(p => p.HasValue && datetime.HasValue && p.Value == datetime.Value).WithDefaultMessage(ErrorMessages.IsSameAs, datetime);

        public static IValitRule<TObject, DateTime?> Required<TObject>(this IValitRule<TObject, DateTime?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue).WithDefaultMessage(ErrorMessages.Required);
    }
}
