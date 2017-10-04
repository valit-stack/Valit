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
        public static IValitRule<TObject, TProperty> Satisfies<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, Predicate<TProperty> predicate) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            predicate.ThrowIfNull(ValitExceptionMessages.NullPredicate);

            var accessor = rule.GetAccessor(); 
            accessor.SetPredicate(predicate);

            return new ValitRule<TObject, TProperty>(rule);
        }

        public static IValitRule<TObject, TProperty> Required<TObject, TProperty>(this IValitRule<TObject, TProperty> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p != null && !p.Equals(default(TProperty)));
        }

        public static IValitRule<TObject, TProperty> IsEqualTo<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, TProperty expectedValue) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);            
            return rule.Satisfies(p => p != null && p.Equals(expectedValue));
        }
        
        public static IValitRule<TObject, TProperty> IsGreaterThan<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, TProperty expectedValue)  where TObject : class
            where TProperty : IComparable
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule); 
            return rule.Satisfies(p => 
                p != null 
                && expectedValue != null 
                && typeof(TProperty).IsNumericType() 
                && Comparer<TProperty>.Default.Compare(p, expectedValue) > 0);
        }         

        public static IValitRule<TObject, TProperty> IsLessThan<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, TProperty expectedValue) where TObject : class
            where TProperty : IComparable
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);             
            return rule.Satisfies(p => 
                p != null 
                && expectedValue != null 
                && typeof(TProperty).IsNumericType() 
                && Comparer<TProperty>.Default.Compare(p, expectedValue) < 0);
        }      

        public static IValitRule<TObject, TProperty> MinLength<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, int length) where TObject : class
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

        public static IValitRule<TObject, TProperty> MaxLength<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, int length) where TObject : class
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

        public static IValitRule<TObject, TProperty> Matches<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, string regularExpression) where TObject : class
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

        public static IValitRule<TObject, TProperty> MinItems<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, int expectedItemsNumber) where TObject : class
            where TProperty : IEnumerable
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);             
            return rule.Satisfies(p => 
                p != null
                && p.Count() >= expectedItemsNumber);
        }

        public static IValitRule<TObject, TProperty> MaxItems<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, int expectedItemsNumber) where TObject : class
            where TProperty : IEnumerable
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);                  
            return rule.Satisfies(p => 
                p != null
                && p.Count() <= expectedItemsNumber);
        }

        public static IValitRule<TObject, TProperty> Email<TObject, TProperty>(this IValitRule<TObject, TProperty> rule) where TObject : class
            where TProperty : IEnumerable<char>, IComparable<String>, IEquatable<String>
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);                  
            return rule.Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static IValitRule<TObject, TProperty> When<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, Predicate<TObject> condition) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);             
            condition.ThrowIfNull(ValitExceptionMessages.NullPredicate);

            var accessor = rule.GetAccessor();
            var previousRuleAccessor = accessor.PreviousRule.GetAccessor();

            previousRuleAccessor.AddCondition(condition);            
            return new ValitRule<TObject, TProperty>(accessor.PreviousRule);
        }

        public static IValitRule<TObject, TProperty> WithMessage<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, string message) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            message.ThrowIfNull();             
            
            var accessor = rule.GetAccessor();
            var previousRuleAccessor = accessor.PreviousRule.GetAccessor();

            var error = ValitRuleError.CreateForMessage(message);
            previousRuleAccessor.AddError(error);
            return new ValitRule<TObject, TProperty>(accessor.PreviousRule);
        }    

        public static IValitRule<TObject, TProperty> WithErrorCode<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, int errorCode) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            
            var accessor = rule.GetAccessor();
            var previousRuleAccessor = accessor.PreviousRule.GetAccessor();

            var error = ValitRuleError.CreateForErrorCode(errorCode);
            previousRuleAccessor.AddError(error);
            return new ValitRule<TObject, TProperty>(accessor.PreviousRule);
        }           

        public static IValitRule<TObject, TProperty> Tag<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, params string[] tags) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);             
            tags.ThrowIfNull();

            var accessor = rule.GetAccessor();
            var previousRuleAccessor = accessor.PreviousRule.GetAccessor();

            previousRuleAccessor.AddTags(tags);            
            return new ValitRule<TObject, TProperty>(accessor.PreviousRule);
        }

        internal static IEnumerable<IValitRule<TObject>> GetAllEnsureRules<TObject, TProperty>(this IValitRule<TObject, TProperty> rule) where TObject : class
        {
            var rules = new List<IValitRule<TObject>>();
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
