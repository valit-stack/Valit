using Valit.Errors;

namespace Valit
{
    public static class ValitRuleUInt32Extensions
    {
        public static IValitRule<TObject, uint> IsGreaterThan<TObject>(this IValitRule<TObject, uint> rule, uint value) where TObject : class
            => rule.Satisfies(p => p > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, uint> IsGreaterThan<TObject>(this IValitRule<TObject, uint> rule, uint? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);


        public static IValitRule<TObject, uint?> IsGreaterThan<TObject>(this IValitRule<TObject, uint?> rule, uint value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);

        public static IValitRule<TObject, uint?> IsGreaterThan<TObject>(this IValitRule<TObject, uint?> rule, uint? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value > value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThan, value);


        public static IValitRule<TObject, uint> IsLessThan<TObject>(this IValitRule<TObject, uint> rule, uint value) where TObject : class
            => rule.Satisfies(p => p < value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, uint> IsLessThan<TObject>(this IValitRule<TObject, uint> rule, uint? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p < value.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);


        public static IValitRule<TObject, uint?> IsLessThan<TObject>(this IValitRule<TObject, uint?> rule, uint value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < value).WithDefaultMessage(ErrorMessages.IsLessThan, value);

        public static IValitRule<TObject, uint?> IsLessThan<TObject>(this IValitRule<TObject, uint?> rule, uint? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value < value.Value).WithDefaultMessage(ErrorMessages.IsLessThan, value);


        public static IValitRule<TObject, uint> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, uint> rule, uint value) where TObject : class
            => rule.Satisfies(p => p >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, uint> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, uint> rule, uint? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);


        public static IValitRule<TObject, uint?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, uint?> rule, uint value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value >= value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);

        public static IValitRule<TObject, uint?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, uint?> rule, uint? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value >= value.Value).WithDefaultMessage(ErrorMessages.IsGreaterThanOrEqualTo, value);


        public static IValitRule<TObject, uint> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, uint> rule, uint value) where TObject : class
            => rule.Satisfies(p => p <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, uint> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, uint> rule, uint? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);


        public static IValitRule<TObject, uint?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, uint?> rule, uint value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value <= value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);

        public static IValitRule<TObject, uint?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, uint?> rule, uint? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value <= value.Value).WithDefaultMessage(ErrorMessages.IsLessThanOrEqualTo, value);


        public static IValitRule<TObject, uint> IsEqualTo<TObject>(this IValitRule<TObject, uint> rule, uint value) where TObject : class
            => rule.Satisfies(p => p == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, uint> IsEqualTo<TObject>(this IValitRule<TObject, uint> rule, uint? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);


        public static IValitRule<TObject, uint?> IsEqualTo<TObject>(this IValitRule<TObject, uint?> rule, uint value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, uint?> IsEqualTo<TObject>(this IValitRule<TObject, uint?> rule, uint? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value == value.Value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);


        public static IValitRule<TObject, uint> IsNonZero<TObject>(this IValitRule<TObject, uint> rule) where TObject : class
            => rule.Satisfies(p => p != 0u).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, uint?> IsNonZero<TObject>(this IValitRule<TObject, uint?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value != 0u).WithDefaultMessage(ErrorMessages.IsNonZero);

        public static IValitRule<TObject, uint?> Required<TObject>(this IValitRule<TObject, uint?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue).WithDefaultMessage(ErrorMessages.Required);
    }
}
