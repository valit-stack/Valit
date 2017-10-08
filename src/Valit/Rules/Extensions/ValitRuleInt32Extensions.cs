using System;

namespace Valit
{
    public static class ValitRuleInt32Extensions
    {
        public static IValitRule<TObject, int> IsGreaterThan<TObject>(this IValitRule<TObject, int> rule, int value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p > value);      
        }   

        public static IValitRule<TObject, int> IsLessThan<TObject>(this IValitRule<TObject, int> rule, int value)  where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p < value);      
        }            

        public static IValitRule<TObject, int> IsEqualTo<TObject>(this IValitRule<TObject, int> rule, int value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  p == value);
        }

        public static IValitRule<TObject, int> IsPositive<TObject>(this IValitRule<TObject, int> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  Math.Sign(p) > 0);
        }

        public static IValitRule<TObject, int> IsNegative<TObject>(this IValitRule<TObject, int> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  Math.Sign(p) < 0);
        }

        public static IValitRule<TObject, int> IsNonZero<TObject>(this IValitRule<TObject, int> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p =>  Math.Sign(p) != 0);
        }
    }
}