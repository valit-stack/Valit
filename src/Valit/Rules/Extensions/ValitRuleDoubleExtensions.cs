using System;

namespace Valit
{
    public static class ValitRuleDoubleExtensions
    {
        public static IValitRule<TObject, double> IsGreaterThan<TObject>(this IValitRule<TObject, double> rule, double value)  where TObject : class
            => rule.Satisfies(p =>  !Double.IsNaN(p) && !Double.IsNaN(value) && p > value);         

        public static IValitRule<TObject, double> IsLessThan<TObject>(this IValitRule<TObject, double> rule, double value)  where TObject : class
            => rule.Satisfies(p =>  !Double.IsNaN(p) && !Double.IsNaN(value) && value > p);                 

        public static IValitRule<TObject, double> IsEqualTo<TObject>(this IValitRule<TObject, double> rule, double value) where TObject : class
            => rule.Satisfies(p =>  !Double.IsNaN(p) && !Double.IsNaN(value) && p == value);

        public static IValitRule<TObject, double> IsPositive<TObject>(this IValitRule<TObject, double> rule) where TObject : class
            => rule.Satisfies(p =>  !Double.IsNaN(p) && Math.Sign(p) > 0); 

        public static IValitRule<TObject, double> IsNegative<TObject>(this IValitRule<TObject, double> rule) where TObject : class
            => rule.Satisfies(p =>  !Double.IsNaN(p) && Math.Sign(p) < 0); 

        public static IValitRule<TObject, double> IsNonZero<TObject>(this IValitRule<TObject, double> rule) where TObject : class
            => rule.Satisfies(p =>  !Double.IsNaN(p) && Math.Sign(p) != 0);
    }
}