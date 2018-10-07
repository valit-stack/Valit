using System;
using System.Text.RegularExpressions;
using Valit.Errors;

namespace Valit
{
    public static class ValitRuleStringExtensions
    {
        private static string _emailRegularExpression => @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        public static IValitRule<TObject, string> IsEqualTo<TObject>(this IValitRule<TObject, string> rule, string value) where TObject : class
            => rule.Satisfies(p => p != null && value != null && p == value).WithDefaultMessage(ErrorMessages.IsEqualTo, value);

        public static IValitRule<TObject, string> MinLength<TObject>(this IValitRule<TObject, string> rule, int length) where TObject : class
            => rule.Satisfies(p => p != null && p.Length >= length).WithDefaultMessage(ErrorMessages.MinLength, length);

        public static IValitRule<TObject, string> MaxLength<TObject>(this IValitRule<TObject, string> rule, int length) where TObject : class
            => rule.Satisfies(p => p != null && p.Length <= length).WithDefaultMessage(ErrorMessages.MaxLength, length);

        public static IValitRule<TObject, string> Matches<TObject>(this IValitRule<TObject, string> rule, string regularExpression) where TObject : class
            => rule.Satisfies(p => p != null && !String.IsNullOrEmpty(regularExpression) && Regex.IsMatch(p, regularExpression)).WithDefaultMessage(ErrorMessages.Matches, regularExpression);

        public static IValitRule<TObject, string> Email<TObject>(this IValitRule<TObject, string> rule) where TObject : class
            => rule.Satisfies(p => p != null && !String.IsNullOrEmpty(_emailRegularExpression) && Regex.IsMatch(p, _emailRegularExpression)).WithDefaultMessage(ErrorMessages.Email);

        public static IValitRule<TObject, string> Required<TObject>(this IValitRule<TObject, string> rule) where TObject : class
            => rule.Satisfies(p => p != null).WithDefaultMessage(ErrorMessages.Required);
    }
}
