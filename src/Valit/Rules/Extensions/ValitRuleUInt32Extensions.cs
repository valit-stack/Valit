using System;

namespace Valit
{
    public static class ValitRuleUInt32Extensions
    {
        public static IValitRule<TObject, uint> IsGreaterThan<TObject>(this IValitRule<TObject, uint> rule, uint value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p > value);      
        }

        public static IValitRule<TObject, uint?> IsGreaterThan<TObject>(this IValitRule<TObject, uint?> rule, uint value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p > value);
        }

        public static IValitRule<TObject, uint> IsLessThan<TObject>(this IValitRule<TObject, uint> rule, uint value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p < value);      
        }

        public static IValitRule<TObject, uint?> IsLessThan<TObject>(this IValitRule<TObject, uint?> rule, uint value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p < value);
        }

        public static IValitRule<TObject, uint> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, uint> rule, uint value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p =>  p >= value);
        }

        public static IValitRule<TObject, uint?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, uint?> rule, uint value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p >= value);
        }

        public static IValitRule<TObject, uint> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, uint> rule, uint value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p =>  p <= value);
        }

        public static IValitRule<TObject, uint?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, uint?> rule, uint value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p <= value);
        }

        public static IValitRule<TObject, uint> IsEqualTo<TObject>(this IValitRule<TObject, uint> rule, uint value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p == value);
        }

        public static IValitRule<TObject, uint?> IsEqualTo<TObject>(this IValitRule<TObject, uint?> rule, uint value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p == value);
        }

        public static IValitRule<TObject, uint> IsNonZero<TObject>(this IValitRule<TObject, uint> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p => p != 0u);
        }

        public static IValitRule<TObject, uint?> IsNonZero<TObject>(this IValitRule<TObject, uint?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p != 0u);
        }

        public static IValitRule<TObject, uint?> Required<TObject>(this IValitRule<TObject, uint?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue);
        }
    }
}