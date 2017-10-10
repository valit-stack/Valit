using System;

namespace Valit
{
    public static class ValitRuleUInt16Extensions
    {
        public static IValitRule<TObject, ushort> IsGreaterThan<TObject>(this IValitRule<TObject, ushort> rule, ushort value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p > value);      
        }

        public static IValitRule<TObject, ushort?> IsGreaterThan<TObject>(this IValitRule<TObject, ushort?> rule, ushort value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p > value);
        }

        public static IValitRule<TObject, ushort> IsLessThan<TObject>(this IValitRule<TObject, ushort> rule, ushort value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p < value);
        }

        public static IValitRule<TObject, ushort?> IsLessThan<TObject>(this IValitRule<TObject, ushort?> rule, ushort value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p < value);
        }

        public static IValitRule<TObject, ushort> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, ushort> rule, ushort value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p =>  p >= value);
        }

        public static IValitRule<TObject, ushort?> IsGreaterThanOrEqualTo<TObject>(this IValitRule<TObject, ushort?> rule, ushort value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p >= value);
        }

        public static IValitRule<TObject, ushort> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, ushort> rule, ushort value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p =>  p <= value);
        }

        public static IValitRule<TObject, ushort?> IsLessThanOrEqualTo<TObject>(this IValitRule<TObject, ushort?> rule, ushort value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p <= value);
        }

        public static IValitRule<TObject, ushort> IsEqualTo<TObject>(this IValitRule<TObject, ushort> rule, ushort value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p == value);
        }

        public static IValitRule<TObject, ushort?> IsEqualTo<TObject>(this IValitRule<TObject, ushort?> rule, ushort value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p == value);
        }

        public static IValitRule<TObject, ushort> IsNonZero<TObject>(this IValitRule<TObject, ushort> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p => p != 0);
        }

        public static IValitRule<TObject, ushort?> IsNonZero<TObject>(this IValitRule<TObject, ushort?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue && p != 0);
        }

        public static IValitRule<TObject, ushort?> Required<TObject>(this IValitRule<TObject, ushort?> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p.HasValue);
        }
    }
}