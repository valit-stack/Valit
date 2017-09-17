using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Valit.Enums;
using Valit.Rules;

namespace Valit.Extensions
{
    public static class ValitRuleExtensions
    {
        public static IValitRule<TProperty> Satisfies<TProperty>(this IValitRule<TProperty> rule, Predicate<TProperty> predicate)
        {
            var accessor = rule.GetAccessor();
            var previousRuleAccessor = accessor.PreviousRule.GetAccessor();
            accessor.IsSatisfied = previousRuleAccessor.IsSatisfied && predicate(accessor.Property);
            return new ValitRule<TProperty>(rule);
        }

        public static IValitRule<TProperty> Required<TProperty>(this IValitRule<TProperty> rule)
        {
            return rule.Satisfies(p => p != null && !p.Equals(default(TProperty)));
        }

        public static IValitRule<TProperty> IsEqualTo<TProperty>(this IValitRule<TProperty> rule, TProperty expectedValue)
        {
            return rule.Satisfies(p => p != null && p.Equals(expectedValue));
        }
        
        public static IValitRule<TProperty> IsGreaterThan<TProperty>(this IValitRule<TProperty> rule, TProperty expectedValue) 
            where TProperty : IComparable
        {
            return rule.Satisfies(p => 
                p != null 
                && expectedValue != null 
                && typeof(TProperty).IsNumericType() 
                && Comparer<TProperty>.Default.Compare(p, expectedValue) > 0);
        }         

        public static IValitRule<TProperty> IsLessThan<TProperty>(this IValitRule<TProperty> rule, TProperty expectedValue) 
            where TProperty : IComparable
        {
            return rule.Satisfies(p => 
                p != null 
                && expectedValue != null 
                && typeof(TProperty).IsNumericType() 
                && Comparer<TProperty>.Default.Compare(p, expectedValue) < 0);
        }      

        public static IValitRule<TProperty> MinLength<TProperty>(this IValitRule<TProperty> rule, int length) 
            where TProperty : IEnumerable<char>, IComparable<String>, IEquatable<String>
        {
            var typeCode = Type.GetTypeCode(typeof(TProperty));
            return rule.Satisfies(p => 
                p != null
                && typeCode == TypeCode.String 
                && !String.IsNullOrEmpty(p as string)
                && (p as string).Length >= length);
        }

        public static IValitRule<TProperty> MaxLength<TProperty>(this IValitRule<TProperty> rule, int length) 
            where TProperty : IEnumerable<char>, IComparable<String>, IEquatable<String>
        {
            var typeCode = Type.GetTypeCode(typeof(TProperty));
            return rule.Satisfies(p => 
                p != null
                && typeCode == TypeCode.String 
                && !String.IsNullOrEmpty(p as string)
                && (p as string).Length <= length);
        }

        public static IValitRule<TProperty> Matches<TProperty>(this IValitRule<TProperty> rule, string regularExpression) 
            where TProperty : IEnumerable<char>, IComparable<String>, IEquatable<String>
        {
            var typeCode = Type.GetTypeCode(typeof(TProperty));
            return rule.Satisfies(p => 
                p != null 
                && !String.IsNullOrEmpty(regularExpression) 
                && typeCode == TypeCode.String 
                && Regex.IsMatch(p as string, regularExpression));
        }

        public static IValitRule<TProperty> MinItems<TProperty>(this IValitRule<TProperty> rule, int expectedItemsNumber) 
            where TProperty : IEnumerable
        {
            return rule.Satisfies(p => 
                p != null
                && p.Count() >= expectedItemsNumber);
        }

        public static IValitRule<TProperty> MaxItems<TProperty>(this IValitRule<TProperty> rule, int expectedItemsNumber) 
            where TProperty : IEnumerable
        {
            return rule.Satisfies(p => 
                p != null
                && p.Count() <= expectedItemsNumber);
        }

        public static IValitRule<TProperty> When<TProperty>(this IValitRule<TProperty> rule, Func<bool> predicate)
        {
            var accessor = rule.GetAccessor();
            var previousRuleAccessor = accessor.PreviousRule.GetAccessor();

            var isApplicable = predicate();
            previousRuleAccessor.IsSatisfied = isApplicable ? previousRuleAccessor.IsSatisfied : true;
            return new ValitRule<TProperty>(accessor.PreviousRule);
        }

        public static IValitRule<TProperty> WithMessage<TProperty>(this IValitRule<TProperty> rule, string message)
        {
            var accessor = rule.GetAccessor();
            var previousRuleAccessor = accessor.PreviousRule.GetAccessor();

            if (!previousRuleAccessor.IsSatisfied) 
            {
                accessor.ErrorMessages.Add(message);
            }
            return new ValitRule<TProperty>(accessor.PreviousRule);
        }        
    }
}
