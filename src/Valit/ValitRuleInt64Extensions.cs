namespace Valit
{
    public static class ValitRuleInt64Extensions
    {
        public static IValitRule<TObject, long> IsGreaterThan<TObject>(this IValitRule<TObject, long> rule, long value) where TObject : class
            => rule.Satisfies(p => p > value);

        public static IValitRule<TObject, long> IsGreaterThan<TObject>(this IValitRule<TObject, long> rule, long? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p > value.Value);


        public static IValitRule<TObject, long?> IsGreaterThan<TObject>(this IValitRule<TObject, long?> rule, long value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > value);

        public static IValitRule<TObject, long?> IsGreaterThan<TObject>(this IValitRule<TObject, long?> rule, long? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value > value.Value);


        public static IValitRule<TObject, long> IsLessThan<TObject>(this IValitRule<TObject, long> rule, long value) where TObject : class
            => rule.Satisfies(p => p < value);

        public static IValitRule<TObject, long> IsLessThan<TObject>(this IValitRule<TObject, long> rule, long? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p < value.Value);


        public static IValitRule<TObject, long?> IsLessThan<TObject>(this IValitRule<TObject, long?> rule, long value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < value);

        public static IValitRule<TObject, long?> IsLessThan<TObject>(this IValitRule<TObject, long?> rule, long? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value < value.Value);


        public static IValitRule<TObject, long> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, long> rule, long value) where TObject : class
            => rule.Satisfies(p => p >= value);

        public static IValitRule<TObject, long> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, long> rule, long? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p >= value.Value);


        public static IValitRule<TObject, long?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, long?> rule, long value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value >= value);

        public static IValitRule<TObject, long?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, long?> rule, long? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value >= value.Value);


        public static IValitRule<TObject, long> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, long> rule, long value) where TObject : class
            => rule.Satisfies(p => p <= value);

        public static IValitRule<TObject, long> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, long> rule, long? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p <= value.Value);


        public static IValitRule<TObject, long?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, long?> rule, long value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value <= value);

        public static IValitRule<TObject, long?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, long?> rule, long? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value <= value.Value);


        public static IValitRule<TObject, long> IsEqualTo<TObject>(this IValitRule<TObject, long> rule, long value) where TObject : class
            => rule.Satisfies(p => p == value);

        public static IValitRule<TObject, long> IsEqualTo<TObject>(this IValitRule<TObject, long> rule, long? value) where TObject : class
            => rule.Satisfies(p => value.HasValue && p == value.Value);


        public static IValitRule<TObject, long?> IsEqualTo<TObject>(this IValitRule<TObject, long?> rule, long value) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value == value);

        public static IValitRule<TObject, long?> IsEqualTo<TObject>(this IValitRule<TObject, long?> rule, long? value) where TObject : class
            => rule.Satisfies(p => p.HasValue && value.HasValue && p.Value == value.Value);


        public static IValitRule<TObject, long> IsPositive<TObject>(this IValitRule<TObject, long> rule) where TObject : class
            => rule.Satisfies(p => p > 0L);

        public static IValitRule<TObject, long?> IsPositive<TObject>(this IValitRule<TObject, long?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value > 0L);

        public static IValitRule<TObject, long> IsNegative<TObject>(this IValitRule<TObject, long> rule) where TObject : class
            => rule.Satisfies(p => p < 0L);

        public static IValitRule<TObject, long?> IsNegative<TObject>(this IValitRule<TObject, long?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value < 0L);

        public static IValitRule<TObject, long> IsNonZero<TObject>(this IValitRule<TObject, long> rule) where TObject : class
            => rule.Satisfies(p => p != 0L);

        public static IValitRule<TObject, long?> IsNonZero<TObject>(this IValitRule<TObject, long?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue && p.Value != 0L);

        public static IValitRule<TObject, long?> Required<TObject>(this IValitRule<TObject, long?> rule) where TObject : class
            => rule.Satisfies(p => p.HasValue);
    }
}
