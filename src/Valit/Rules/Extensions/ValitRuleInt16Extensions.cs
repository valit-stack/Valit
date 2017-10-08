using System;

namespace Valit
{
    public static class ValitRuleInt16Extensions
    {
        public static IValitRule<TObject, short> IsGreaterThan<TObject>(this IValitRule<TObject, short> rule, short value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p > value);      
        }   

        public static IValitRule<TObject, short> IsLessThan<TObject>(this IValitRule<TObject, short> rule, short value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p < value);      
        }            

        public static IValitRule<TObject, short> IsEqualTo<TObject>(this IValitRule<TObject, short> rule, short value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p == value);
        }

        public static IValitRule<TObject, short> IsPositive<TObject>(this IValitRule<TObject, short> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  Math.Sign(p) > 0);
        }

        public static IValitRule<TObject, short> IsNegative<TObject>(this IValitRule<TObject, short> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  Math.Sign(p) < 0);
        }

        public static IValitRule<TObject, short> IsNonZero<TObject>(this IValitRule<TObject, short> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  Math.Sign(p) != 0);
        }
    }
}