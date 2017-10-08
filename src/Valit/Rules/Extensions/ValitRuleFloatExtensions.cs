using System;

namespace Valit
{
    public static class ValitRuleFloatExtensions
    {
        public static IValitRule<TObject, float> IsGreaterThan<TObject>(this IValitRule<TObject, float> rule, float value)  where TObject : class
            => rule.Satisfies(p =>  !Double.IsNaN(p) && !Double.IsNaN(value) && p > value);         

        public static IValitRule<TObject, float> IsLessThan<TObject>(this IValitRule<TObject, float> rule, float value)  where TObject : class
            => rule.Satisfies(p =>  !Double.IsNaN(p) && !Double.IsNaN(value) && value > p);                 

        public static IValitRule<TObject, float> IsEqualTo<TObject>(this IValitRule<TObject, float> rule, float value) where TObject : class
            => rule.Satisfies(p =>  !Double.IsNaN(p) && !Double.IsNaN(value) && p == value);

        public static IValitRule<TObject, float> IsPositive<TObject>(this IValitRule<TObject, float> rule) where TObject : class
            => rule.Satisfies(p =>  !Double.IsNaN(p) && Math.Sign(p) > 0); 

        public static IValitRule<TObject, float> IsNegative<TObject>(this IValitRule<TObject, float> rule) where TObject : class
            => rule.Satisfies(p =>  !Double.IsNaN(p) && Math.Sign(p) < 0); 

        public static IValitRule<TObject, float> IsNonZero<TObject>(this IValitRule<TObject, float> rule) where TObject : class
            => rule.Satisfies(p =>  !Double.IsNaN(p) && Math.Sign(p) != 0);
    }
}