using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Valit
{
    public static class ValitRuleExtensions
    {
        public static IValitRule<TProperty> Satisfies<TProperty>(this IValitRule<TProperty> rule, Predicate<TProperty> predicate)
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            predicate.ThrowIfNull(ValitExceptionMessages.NullPredicate);

            var accessor = rule.GetAccessor(); 
            accessor.SetPredicate(predicate);

            return new ValitRule<TProperty>(rule);
        }

        public static IValitRule<TProperty> Required<TProperty>(this IValitRule<TProperty> rule)
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p != null && !p.Equals(default(TProperty)));
        }

        public static IValitRule<TProperty> IsEqualTo<TProperty>(this IValitRule<TProperty> rule, TProperty expectedValue)
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);            
            return rule.Satisfies(p => p != null && p.Equals(expectedValue));
        }
        
        public static IValitRule<TProperty> IsGreaterThan<TProperty>(this IValitRule<TProperty> rule, TProperty expectedValue) 
            where TProperty : IComparable
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule); 
            return rule.Satisfies(p => 
                p != null 
                && expectedValue != null 
                && typeof(TProperty).IsNumericType() 
                && Comparer<TProperty>.Default.Compare(p, expectedValue) > 0);
        }         

        public static IValitRule<TProperty> IsLessThan<TProperty>(this IValitRule<TProperty> rule, TProperty expectedValue) 
            where TProperty : IComparable
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);             
            return rule.Satisfies(p => 
                p != null 
                && expectedValue != null 
                && typeof(TProperty).IsNumericType() 
                && Comparer<TProperty>.Default.Compare(p, expectedValue) < 0);
        }      

        public static IValitRule<TProperty> MinLength<TProperty>(this IValitRule<TProperty> rule, int length) 
            where TProperty : IEnumerable<char>, IComparable<String>, IEquatable<String>
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);             
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
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);             
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
            rule.ThrowIfNull(ValitExceptionMessages.NullRule); 
            regularExpression.ThrowIfNull();            
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
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);             
            return rule.Satisfies(p => 
                p != null
                && p.Count() >= expectedItemsNumber);
        }

        public static IValitRule<TProperty> MaxItems<TProperty>(this IValitRule<TProperty> rule, int expectedItemsNumber) 
            where TProperty : IEnumerable
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);                  
            return rule.Satisfies(p => 
                p != null
                && p.Count() <= expectedItemsNumber);
        }

        public static IValitRule<TProperty> Email<TProperty>(this IValitRule<TProperty> rule) 
            where TProperty : IEnumerable<char>, IComparable<String>, IEquatable<String>
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);                  
            return rule.Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static IValitRule<TProperty> When<TProperty>(this IValitRule<TProperty> rule, Func<bool> predicate)
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);             
            predicate.ThrowIfNull(ValitExceptionMessages.NullPredicate);

            var accessor = rule.GetAccessor();
            var previousRuleAccessor = accessor.PreviousRule.GetAccessor();

            previousRuleAccessor.AddCondition(predicate);            
            return new ValitRule<TProperty>(accessor.PreviousRule);
        }

        public static IValitRule<TProperty> WithMessage<TProperty>(this IValitRule<TProperty> rule, string message)
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            message.ThrowIfNull();             
            
            var accessor = rule.GetAccessor();
            var previousRuleAccessor = accessor.PreviousRule.GetAccessor();

            previousRuleAccessor.AddErrorMessage(message);
            return new ValitRule<TProperty>(accessor.PreviousRule);
        }           

        internal static IEnumerable<IValitRule> GetAllEnsureRules<TProperty>(this IValitRule<TProperty> rule)
        {
            var rules = new List<IValitRule>();
            rules.Add(rule);
            
            var accessor = rule.GetAccessor();
            var previousRule = accessor.PreviousRule;

            while(previousRule != null)
            {
                rules.Insert(0, previousRule);
                previousRule = previousRule.GetAccessor().PreviousRule;
            }

            return rules;
        }      
    }
}
