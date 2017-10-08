using System;

namespace Valit
{
    public static class ValitRuleInt64Extensions
    {
        public static IValitRule<TObject, long> IsGreaterThan<TObject>(this IValitRule<TObject, long> rule, long value)  where TObject : class
            => rule.Satisfies(p =>  p > value);         

        public static IValitRule<TObject, long> IsLessThan<TObject>(this IValitRule<TObject, long> rule, long value)  where TObject : class
            => rule.Satisfies(p =>  p < value);                  

        public static IValitRule<TObject, long> IsEqualTo<TObject>(this IValitRule<TObject, long> rule, long value) where TObject : class
            => rule.Satisfies(p =>  p < value);

        public static IValitRule<TObject, long> IsPositive<TObject>(this IValitRule<TObject, long> rule) where TObject : class
            => rule.Satisfies(p =>  Math.Sign(p) > 0);

        public static IValitRule<TObject, long> IsNegative<TObject>(this IValitRule<TObject, long> rule) where TObject : class
            => rule.Satisfies(p =>  Math.Sign(p) < 0);

        public static IValitRule<TObject, long> IsNonZero<TObject>(this IValitRule<TObject, long> rule) where TObject : class
            => rule.Satisfies(p =>  Math.Sign(p) != 0);
    }
}