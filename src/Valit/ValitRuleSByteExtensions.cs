using Valit.Errors;

namespace Valit
{
    public static class ValitRuleSByteExtensions
    {
        public static IValitRule<TObject, sbyte> IsGreaterThan<TObject>(this IValitRule<TObject, sbyte> rule, sbyte value) where TObject : class
            => rule.Satisfies(p => p > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, sbyte> IsGreaterThan<TObject>(this IValitRule<TObject, sbyte> rule, sbyte? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);


        public static IValitRule<TObject, sbyte?> IsGreaterThan<TObject>(this IValitRule<TObject, sbyte?> rule, sbyte value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, sbyte?> IsGreaterThan<TObject>(this IValitRule<TObject, sbyte?> rule, sbyte? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);


        public static IValitRule<TObject, sbyte> IsLessThan<TObject>(this IValitRule<TObject, sbyte> rule, sbyte value) where TObject : class
            => rule.Satisfies(p => p < value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, sbyte> IsLessThan<TObject>(this IValitRule<TObject, sbyte> rule, sbyte? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p < value.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);


        public static IValitRule<TObject, sbyte?> IsLessThan<TObject>(this IValitRule<TObject, sbyte?> rule, sbyte value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, sbyte?> IsLessThan<TObject>(this IValitRule<TObject, sbyte?> rule, sbyte? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value < value.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);


        public static IValitRule<TObject, sbyte> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, sbyte> rule, sbyte value) where TObject : class
            => rule.Satisfies(p => p >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, sbyte> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, sbyte> rule, sbyte? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);


        public static IValitRule<TObject, sbyte?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, sbyte?> rule, sbyte value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, sbyte?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, sbyte?> rule, sbyte? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);


        public static IValitRule<TObject, sbyte> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, sbyte> rule, sbyte value) where TObject : class
            => rule.Satisfies(p => p <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, sbyte> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, sbyte> rule, sbyte? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);


        public static IValitRule<TObject, sbyte?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, sbyte?> rule, sbyte value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, sbyte?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, sbyte?> rule, sbyte? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);


        public static IValitRule<TObject, sbyte> IsEqualTo<TObject>(this IValitRule<TObject, sbyte> rule, sbyte value) where TObject : class
            => rule.Satisfies(p => p == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, sbyte> IsEqualTo<TObject>(this IValitRule<TObject, sbyte> rule, sbyte? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);


        public static IValitRule<TObject, sbyte?> IsEqualTo<TObject>(this IValitRule<TObject, sbyte?> rule, sbyte value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, sbyte?> IsEqualTo<TObject>(this IValitRule<TObject, sbyte?> rule, sbyte? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);


        public static IValitRule<TObject, sbyte> IsPositive<TObject>(this IValitRule<TObject, sbyte> rule) where TObject : class
            => rule.Satisfies(p => p > 0).WithDefaultMessage(ErrorMessages.IsPositive);

        public static IValitRule<TObject, sbyte?> IsPositive<TObject>(this IValitRule<TObject, sbyte?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > 0).WithDefaultMessage(ErrorMessages.IsPositive);

        public static IValitRule<TObject, sbyte> IsNegative<TObject>(this IValitRule<TObject, sbyte> rule) where TObject : class
            => rule.Satisfies(p => p < 0).WithDefaultMessage(ErrorMessages.IsNegative);

        public static IValitRule<TObject, sbyte?> IsNegative<TObject>(this IValitRule<TObject, sbyte?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < 0).WithDefaultMessage(ErrorMessages.IsNegative);

        public static IValitRule<TObject, sbyte> IsNonZero<TObject>(this IValitRule<TObject, sbyte> rule) where TObject : class
            => rule.Satisfies(p => p != 0).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, sbyte?> IsNonZero<TObject>(this IValitRule<TObject, sbyte?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value != 0).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, sbyte?> Required<TObject>(this IValitRule<TObject, sbyte?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue).WithDefaultMessage(ErrorMessages.Required);
    }
}
