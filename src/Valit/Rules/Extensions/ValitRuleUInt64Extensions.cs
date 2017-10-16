namespace Valit
{
    public static class ValitRuleUInt64Extensions
    {
        public static IValitRule<TObject, ulong> IsGreaterThan<TObject>(this IValitRule<TObject, ulong> rule, ulong value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p > value);      
        }

        public static IValitRule<TObject, ulong> IsGreaterThan<TObject>(this IValitRule<TObject, ulong> rule, ulong? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => value.HasValue && p > value.Value);
        }


        public static IValitRule<TObject, ulong?> IsGreaterThan<TObject>(this IValitRule<TObject, ulong?> rule, ulong value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value > value);
        }

        public static IValitRule<TObject, ulong?> IsGreaterThan<TObject>(this IValitRule<TObject, ulong?> rule, ulong? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && value.HasValue && p.Value > value.Value);
        }


        public static IValitRule<TObject, ulong> IsLessThan<TObject>(this IValitRule<TObject, ulong> rule, ulong value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p < value);      
        }

        public static IValitRule<TObject, ulong> IsLessThan<TObject>(this IValitRule<TObject, ulong> rule, ulong? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => value.HasValue && p < value.Value);
        }


        public static IValitRule<TObject, ulong?> IsLessThan<TObject>(this IValitRule<TObject, ulong?> rule, ulong value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value < value);
        }

        public static IValitRule<TObject, ulong?> IsLessThan<TObject>(this IValitRule<TObject, ulong?> rule, ulong? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && value.HasValue && p.Value < value.Value);
        }


        public static IValitRule<TObject, ulong> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, ulong> rule, ulong value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p =>  p >= value);
        }

        public static IValitRule<TObject, ulong> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, ulong> rule, ulong? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => value.HasValue && p >= value.Value);
        }


        public static IValitRule<TObject, ulong?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, ulong?> rule, ulong value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value >= value);
        }

        public static IValitRule<TObject, ulong?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, ulong?> rule, ulong? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && value.HasValue && p.Value >= value.Value);
        }


        public static IValitRule<TObject, ulong> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, ulong> rule, ulong value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p =>  p <= value);
        }

        public static IValitRule<TObject, ulong> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, ulong> rule, ulong? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => value.HasValue && p <= value.Value);
        }


        public static IValitRule<TObject, ulong?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, ulong?> rule, ulong value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value <= value);
        }

        public static IValitRule<TObject, ulong?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, ulong?> rule, ulong? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && value.HasValue && p.Value <= value.Value);
        }

        public static IValitRule<TObject, ulong> IsEqualTo<TObject>(this IValitRule<TObject, ulong> rule, ulong value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p == value);
        }

        public static IValitRule<TObject, ulong> IsEqualTo<TObject>(this IValitRule<TObject, ulong> rule, ulong? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => value.HasValue && p == value.Value);
        }


        public static IValitRule<TObject, ulong?> IsEqualTo<TObject>(this IValitRule<TObject, ulong?> rule, ulong value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value == value);
        }

        public static IValitRule<TObject, ulong?> IsEqualTo<TObject>(this IValitRule<TObject, ulong?> rule, ulong? value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && value.HasValue && p.Value == value.Value);
        }


        public static IValitRule<TObject, ulong> IsNonZero<TObject>(this IValitRule<TObject, ulong> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p != 0UL);
        }

        public static IValitRule<TObject, ulong?> IsNonZero<TObject>(this IValitRule<TObject, ulong?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p.Value != 0UL);
        }

        public static IValitRule<TObject, ulong?> Required<TObject>(this IValitRule<TObject, ulong?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue);
        }
    }
}