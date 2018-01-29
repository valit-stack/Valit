using System;
using Valit.Errors;

namespace Valit
{
    public static class ValitRuleDateTimeOffsetExtensions
    {
        public static IValitRule<TObject, DateTimeOffset> IsAfter<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset dateTimeOffset) where TObject : class
            => rule.Satisfies(p => p > dateTimeOffset).WithDefaultMessage(ErrorMessages.IsAfter, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset> IsAfter<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset? dateTimeOffset) where TObject : class
            => rule.Satisfies(p => dateTimeOffset.HasValue && p > dateTimeOffset.Value).WithDefaultMessage(ErrorMessages.IsAfterOrSameAs, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset?> IsAfter<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset dateTimeOffset) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > dateTimeOffset).WithDefaultMessage(ErrorMessages.IsAfter, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset?> IsAfter<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset? dateTimeOffset) where TObject : class
            => rule.Satisfies(p => p.HasValue && dateTimeOffset.HasValue && p.Value > dateTimeOffset.Value).WithDefaultMessage(ErrorMessages.IsAfterOrSameAs, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset> IsBefore<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset dateTimeOffset) where TObject : class
            => rule.Satisfies(p => p < dateTimeOffset).WithDefaultMessage(ErrorMessages.IsBefore, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset> IsBefore<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset? dateTimeOffset) where TObject : class
            => rule.Satisfies(p => dateTimeOffset.HasValue && p < dateTimeOffset.Value).WithDefaultMessage(ErrorMessages.IsBefore, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset?> IsBefore<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset dateTimeOffset) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < dateTimeOffset).WithDefaultMessage(ErrorMessages.IsBefore, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset?> IsBefore<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset? dateTimeOffset) where TObject : class
            => rule.Satisfies(p => p.HasValue && dateTimeOffset.HasValue && p.Value < dateTimeOffset.Value).WithDefaultMessage(ErrorMessages.IsBefore, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset> IsAfterOrSameAs<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset dateTimeOffset) where TObject : class
            => rule.Satisfies(p => p >= dateTimeOffset).WithDefaultMessage(ErrorMessages.IsAfterOrSameAs, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset> IsAfterOrSameAs<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset? dateTimeOffset) where TObject : class
            => rule.Satisfies(p => dateTimeOffset.HasValue && p >= dateTimeOffset.Value).WithDefaultMessage(ErrorMessages.IsAfterOrSameAs, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset?> IsAfterOrSameAs<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset dateTimeOffset) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value >= dateTimeOffset).WithDefaultMessage(ErrorMessages.IsAfterOrSameAs, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset?> IsAfterOrSameAs<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset? dateTimeOffset) where TObject : class
            => rule.Satisfies(p => p.HasValue && dateTimeOffset.HasValue && p.Value >= dateTimeOffset.Value).WithDefaultMessage(ErrorMessages.IsAfterOrSameAs, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset> IsBeforeOrSameAs<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset dateTimeOffset) where TObject : class
            => rule.Satisfies(p => p <= dateTimeOffset).WithDefaultMessage(ErrorMessages.IsBeforeOrSameAs, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset> IsBeforeOrSameAs<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset? dateTimeOffset) where TObject : class
            => rule.Satisfies(p => dateTimeOffset.HasValue && p <= dateTimeOffset.Value).WithDefaultMessage(ErrorMessages.IsBeforeOrSameAs, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset?> IsBeforeOrSameAs<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset dateTimeOffset) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value <= dateTimeOffset).WithDefaultMessage(ErrorMessages.IsBeforeOrSameAs, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset?> IsBeforeOrSameAs<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset? dateTimeOffset) where TObject : class
            => rule.Satisfies(p => p.HasValue && dateTimeOffset.HasValue && p.Value <= dateTimeOffset.Value).WithDefaultMessage(ErrorMessages.IsBeforeOrSameAs, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset> IsAfterNow<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
            => rule.Satisfies(p => p > DateTimeOffset.Now).WithDefaultMessage(ErrorMessages.IsAfter, DateTime.Now);

        public static IValitRule<TObject, DateTimeOffset?> IsAfterNow<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > DateTimeOffset.Now).WithDefaultMessage(ErrorMessages.IsAfter, DateTime.Now);

        public static IValitRule<TObject, DateTimeOffset> IsBeforeNow<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
            => rule.Satisfies(p => p < DateTimeOffset.Now).WithDefaultMessage(ErrorMessages.IsBefore, DateTime.Now);

        public static IValitRule<TObject, DateTimeOffset?> IsBeforeNow<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < DateTimeOffset.Now).WithDefaultMessage(ErrorMessages.IsBefore, DateTime.Now);

        public static IValitRule<TObject, DateTimeOffset> IsAfterUtcNow<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
            => rule.Satisfies(p => p > DateTimeOffset.UtcNow).WithDefaultMessage(ErrorMessages.IsAfter, DateTime.UtcNow);

        public static IValitRule<TObject, DateTimeOffset?> IsAfterUtcNow<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > DateTimeOffset.UtcNow).WithDefaultMessage(ErrorMessages.IsAfter, DateTime.UtcNow);

        public static IValitRule<TObject, DateTimeOffset> IsBeforeUtcNow<TObject>(this IValitRule<TObject, DateTimeOffset> rule) where TObject : class
            => rule.Satisfies(p => p < DateTimeOffset.UtcNow).WithDefaultMessage(ErrorMessages.IsBefore, DateTime.UtcNow);

        public static IValitRule<TObject, DateTimeOffset?> IsBeforeUtcNow<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < DateTimeOffset.UtcNow).WithDefaultMessage(ErrorMessages.IsBefore, DateTime.UtcNow);

        public static IValitRule<TObject, DateTimeOffset> IsSameAs<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset dateTimeOffset) where TObject : class
            => rule.Satisfies(p => p == dateTimeOffset).WithDefaultMessage(ErrorMessages.IsSameAs, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset> IsSameAs<TObject>(this IValitRule<TObject, DateTimeOffset> rule, DateTimeOffset? dateTimeOffset) where TObject : class
            => rule.Satisfies(p => dateTimeOffset.HasValue && p == dateTimeOffset.Value).WithDefaultMessage(ErrorMessages.IsSameAs, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset?> IsSameAs<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset dateTimeOffset) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value == dateTimeOffset).WithDefaultMessage(ErrorMessages.IsSameAs, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset?> IsSameAs<TObject>(this IValitRule<TObject, DateTimeOffset?> rule, DateTimeOffset? dateTimeOffset) where TObject : class
            => rule.Satisfies(p => p.HasValue && dateTimeOffset.HasValue && p.Value == dateTimeOffset.Value).WithDefaultMessage(ErrorMessages.IsSameAs, dateTimeOffset);

        public static IValitRule<TObject, DateTimeOffset?> Required<TObject>(this IValitRule<TObject, DateTimeOffset?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue).WithDefaultMessage(ErrorMessages.Required);
    }
}
