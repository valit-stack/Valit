using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Valit.Enums;
using Valit.Rules;

namespace Valit.Extensions
{
    public static class ValitRuleExtensions
    {
        public static IValitRule<TProperty> Satisifes<TProperty>(this IValitRule<TProperty> rule, Func<TProperty, bool> predicate)
        {
            var accessor = rule.GetAccessor();
            accessor.Kind = ValitRuleKinds.Rule;
            accessor.IsSatisfied = predicate(accessor.Property);
            return new ValitRule<TProperty>(rule);
        }

        public static IValitRule<TProperty> Required<TProperty>(this IValitRule<TProperty> rule)
        {
            return rule.Satisifes(p => p != null && !p.Equals(default(TProperty)));
        }

        public static IValitRule<TProperty> IsEqualTo<TProperty>(this IValitRule<TProperty> rule, TProperty expectedValue)
        {
            return rule.Satisifes(p => p != null && p.Equals(expectedValue));
        }

        public static IValitRule<TProperty> IsGreaterThan<TProperty>(this IValitRule<TProperty> rule, TProperty expectedValue) where TProperty : IComparable
        {
            return rule.Satisifes(p => p != null && expectedValue != null && typeof(TProperty).IsNumericType() && Comparer<TProperty>.Default.Compare(p, expectedValue) > 0);
        }         

        public static IValitRule<TProperty> IsLessThan<TProperty>(this IValitRule<TProperty> rule, TProperty expectedValue) where TProperty : IComparable
        {
            return rule.Satisifes(p => p != null && expectedValue != null && typeof(TProperty).IsNumericType() && Comparer<TProperty>.Default.Compare(p, expectedValue) < 0);
        }        

        public static IValitRule<TProperty> Matches<TProperty>(this IValitRule<TProperty> rule, string regularExpression) where TProperty : IEnumerable<char>, IComparable<String>, IEquatable<String>
        {
            var typeCode = Type.GetTypeCode(typeof(TProperty));
            return rule.Satisifes(p => p != null && !String.IsNullOrEmpty(regularExpression) && typeCode == TypeCode.String && Regex.IsMatch(p as string, regularExpression));
        }

        public static IValitRule<TProperty> Email<TProperty>(this IValitRule<TProperty> rule) where TProperty : IEnumerable<char>, IComparable<String>, IEquatable<String>
        {
            return rule.Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static IValitRule<TProperty> WithMessage<TProperty>(this IValitRule<TProperty> rule, string message)
        {
            var accessor = rule.GetAccessor();
            var previousRuleAccessor = accessor.PreviousRule.GetAccessor();

            if (previousRuleAccessor.Kind == ValitRuleKinds.Message) throw new ArgumentException();
            if (!previousRuleAccessor.IsSatisfied) accessor.ErrorMessages.Add(message);

            accessor.Kind = ValitRuleKinds.Message;
            return new ValitRule<TProperty>(rule);
        }        
    }
}
