using System;
using System.Text.RegularExpressions;
using Valit.Exceptions;

namespace Valit
{
    public static class ValitRuleStringExtensions
    {
        public static IValitRule<TObject, string> IsEqualTo<TObject>(this IValitRule<TObject, string> rule, string value) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);       
            return rule.Satisfies(p => !String.IsNullOrEmpty(p) && !String.IsNullOrEmpty(value) && p == value);
        }   

        public static IValitRule<TObject, string> MinLength<TObject>(this IValitRule<TObject, string> rule, int length) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule); 
            return rule.Satisfies(p => !String.IsNullOrEmpty(p) && p.Length >= length);
        }

        public static IValitRule<TObject, string> MaxLength<TObject>(this IValitRule<TObject, string> rule, int length) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule.Satisfies(p => !String.IsNullOrEmpty(p) && p.Length <= length);
        }

        public static IValitRule<TObject, string> Matches<TObject>(this IValitRule<TObject, string> rule, string regularExpression) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => !String.IsNullOrEmpty(p) && !String.IsNullOrEmpty(regularExpression) && Regex.IsMatch(p, regularExpression));
        }

        public static IValitRule<TObject, string> Email<TObject>(this IValitRule<TObject, string> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);                  
            return rule.Matches(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
        }
    }
}