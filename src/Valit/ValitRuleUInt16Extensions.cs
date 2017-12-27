using Valit.Errors;

namespace Valit
{
    public static class ValitRuleUInt16Extensions
    {
        public static IValitRule<TObject, ushort> IsGreaterThan<TObject>(this IValitRule<TObject, ushort> rule, ushort value) where TObject : class
            => rule.Satisfies(p => p > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, ushort> IsGreaterThan<TObject>(this IValitRule<TObject, ushort> rule, ushort? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);


        public static IValitRule<TObject, ushort?> IsGreaterThan<TObject>(this IValitRule<TObject, ushort?> rule, ushort value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, ushort?> IsGreaterThan<TObject>(this IValitRule<TObject, ushort?> rule, ushort? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);


        public static IValitRule<TObject, ushort> IsLessThan<TObject>(this IValitRule<TObject, ushort> rule, ushort value) where TObject : class
            => rule.Satisfies(p => p < value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, ushort> IsLessThan<TObject>(this IValitRule<TObject, ushort> rule, ushort? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p < value.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);


        public static IValitRule<TObject, ushort?> IsLessThan<TObject>(this IValitRule<TObject, ushort?> rule, ushort value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, ushort?> IsLessThan<TObject>(this IValitRule<TObject, ushort?> rule, ushort? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value < value.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);


        public static IValitRule<TObject, ushort> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, ushort> rule, ushort value) where TObject : class
            => rule.Satisfies(p => p >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, ushort> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, ushort> rule, ushort? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);


        public static IValitRule<TObject, ushort?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, ushort?> rule, ushort value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, ushort?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, ushort?> rule, ushort? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);


        public static IValitRule<TObject, ushort> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, ushort> rule, ushort value) where TObject : class
            => rule.Satisfies(p => p <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, ushort> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, ushort> rule, ushort? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);


        public static IValitRule<TObject, ushort?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, ushort?> rule, ushort value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, ushort?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, ushort?> rule, ushort? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);


        public static IValitRule<TObject, ushort> IsEqualTo<TObject>(this IValitRule<TObject, ushort> rule, ushort value) where TObject : class
            => rule.Satisfies(p => p == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, ushort> IsEqualTo<TObject>(this IValitRule<TObject, ushort> rule, ushort? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);


        public static IValitRule<TObject, ushort?> IsEqualTo<TObject>(this IValitRule<TObject, ushort?> rule, ushort value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, ushort?> IsEqualTo<TObject>(this IValitRule<TObject, ushort?> rule, ushort? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, ushort> IsNonZero<TObject>(this IValitRule<TObject, ushort> rule) where TObject : class
            => rule.Satisfies(p => p != 0).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, ushort?> IsNonZero<TObject>(this IValitRule<TObject, ushort?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value != 0).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, ushort?> Required<TObject>(this IValitRule<TObject, ushort?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue).WithDefaultMessage(ErrorMessages.Required);
    }
}
