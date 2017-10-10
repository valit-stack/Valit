namespace Valit
{
    public static class ValitRuleDecimalExtensions
    {
        public static IValitRule<TObject, decimal> IsGreaterThan<TObject>(this IValitRule<TObject, decimal> rule, decimal value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p > value);   
        }

        public static IValitRule<TObject, decimal?> IsGreaterThan<TObject>(this IValitRule<TObject, decimal?> rule, decimal value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p > value);
        }

        public static IValitRule<TObject, decimal> IsLessThan<TObject>(this IValitRule<TObject, decimal> rule, decimal value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p < value);
        }

        public static IValitRule<TObject, decimal?> IsLessThan<TObject>(this IValitRule<TObject, decimal?> rule, decimal value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p < value);
        }

        public static IValitRule<TObject, decimal> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, decimal> rule, decimal value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p =>  p >= value);
        }

        public static IValitRule<TObject, decimal?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, decimal?> rule, decimal value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p >= value);
        }

        public static IValitRule<TObject, decimal> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, decimal> rule, decimal value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p =>  p <= value);
        }

        public static IValitRule<TObject, decimal?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, decimal?> rule, decimal value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p <= value);
        }

        public static IValitRule<TObject, decimal> IsEqualTo<TObject>(this IValitRule<TObject, decimal> rule, decimal value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p == value);
        }

        public static IValitRule<TObject, decimal?> IsEqualTo<TObject>(this IValitRule<TObject, decimal?> rule, decimal value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p == value);
        }

        public static IValitRule<TObject, decimal> IsPositive<TObject>(this IValitRule<TObject, decimal> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p => p > 0m);
        }

        public static IValitRule<TObject, decimal?> IsPositive<TObject>(this IValitRule<TObject, decimal?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p > 0m);
        }

        public static IValitRule<TObject, decimal> IsNegative<TObject>(this IValitRule<TObject, decimal> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p => p < 0m);
        }

        public static IValitRule<TObject, decimal?> IsNegative<TObject>(this IValitRule<TObject, decimal?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p < 0m);
        }

        public static IValitRule<TObject, decimal> IsNonZero<TObject>(this IValitRule<TObject, decimal> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p => p != 0m);
        }

        public static IValitRule<TObject, decimal?> IsNonZero<TObject>(this IValitRule<TObject, decimal?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p != 0m);
        }

        public static IValitRule<TObject, decimal?> Required<TObject>(this IValitRule<TObject, decimal?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue);
        }
    }
}