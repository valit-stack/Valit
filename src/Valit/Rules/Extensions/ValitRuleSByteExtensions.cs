using System;

namespace Valit
{
    public static class ValitRuleSByteExtensions
    {
        public static IValitRule<TObject, sbyte> IsGreaterThan<TObject>(this IValitRule<TObject, sbyte> rule, sbyte value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p > value);      
        }   

        public static IValitRule<TObject, sbyte> IsLessThan<TObject>(this IValitRule<TObject, sbyte> rule, sbyte value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p < value);      
        }   

        public static IValitRule<TObject, sbyte> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, sbyte> rule, sbyte value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p =>  p >= value);
        }          

        public static IValitRule<TObject, sbyte> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, sbyte> rule, sbyte value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p =>  p <= value);
        }         

        public static IValitRule<TObject, sbyte> IsEqualTo<TObject>(this IValitRule<TObject, sbyte> rule, sbyte value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p == value);
        }

        public static IValitRule<TObject, sbyte> IsPositive<TObject>(this IValitRule<TObject, sbyte> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p > 0);
        }

        public static IValitRule<TObject, sbyte> IsNegative<TObject>(this IValitRule<TObject, sbyte> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p < 0);
        }

        public static IValitRule<TObject, sbyte> IsNonZero<TObject>(this IValitRule<TObject, sbyte> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p != 0);
        }

        public static IValitRule<TObject, sbyte?> IsGreaterThan<TObject>(this IValitRule<TObject, sbyte?> rule, sbyte value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p > value);
        }

        public static IValitRule<TObject, sbyte?> IsLessThan<TObject>(this IValitRule<TObject, sbyte?> rule, sbyte value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p < value);
        }

        public static IValitRule<TObject, sbyte?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, sbyte?> rule, sbyte value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p >= value);
        }

        public static IValitRule<TObject, sbyte?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, sbyte?> rule, sbyte value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p <= value);
        }

        public static IValitRule<TObject, sbyte?> IsEqualTo<TObject>(this IValitRule<TObject, sbyte?> rule, sbyte value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p == value);
        }

        public static IValitRule<TObject, sbyte?> IsPositive<TObject>(this IValitRule<TObject, sbyte?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p > 0);
        }

        public static IValitRule<TObject, sbyte?> IsNegative<TObject>(this IValitRule<TObject, sbyte?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p < 0);
        }

        public static IValitRule<TObject, sbyte?> IsNonZero<TObject>(this IValitRule<TObject, sbyte?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p != 0);
        }

        public static IValitRule<TObject, sbyte?> IsNotNull<TObject>(this IValitRule<TObject, sbyte?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue);
        }
    }
}