using System;
using System.Collections.Generic;


namespace Valit
{
    public static class ValitRuleByteExtensions
    {
        public static IValitRule<TObject, byte> IsGreaterThan<TObject>(this IValitRule<TObject, byte> rule, byte value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p =>  p > value);
        }          

        public static IValitRule<TObject, byte> IsLessThan<TObject>(this IValitRule<TObject, byte> rule, byte value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p =>  p < value);
        }    

        public static IValitRule<TObject, byte> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, byte> rule, byte value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p =>  p >= value);
        }          

        public static IValitRule<TObject, byte> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, byte> rule, byte value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p =>  p <= value);
        }               

        public static IValitRule<TObject, byte> IsEqualTo<TObject>(this IValitRule<TObject, byte> rule, byte value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);            
            return rule.Satisfies(p =>  p == value);
        }

        public static IValitRule<TObject, byte> IsNonZero<TObject>(this IValitRule<TObject, byte> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p != 0);
        }

        public static IValitRule<TObject, byte?> IsGreaterThan<TObject>(this IValitRule<TObject, byte?> rule, byte value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p > value);
        }

        public static IValitRule<TObject, byte?> IsLessThan<TObject>(this IValitRule<TObject, byte?> rule, byte value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p < value);
        }

        public static IValitRule<TObject, byte?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, byte?> rule, byte value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p >= value);
        }

        public static IValitRule<TObject, byte?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, byte?> rule, byte value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p <= value);
        }

        public static IValitRule<TObject, byte?> IsEqualTo<TObject>(this IValitRule<TObject, byte?> rule, byte value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p == value);
        }

        public static IValitRule<TObject, byte?> IsNonZero<TObject>(this IValitRule<TObject, byte?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p != 0);
        }

        public static IValitRule<TObject, byte?> Required<TObject>(this IValitRule<TObject, byte?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue);
        }
    }
}
