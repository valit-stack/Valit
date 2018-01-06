using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Valit.Errors;
using Valit.Exceptions;
using Valit.Rules;

namespace Valit
{
    public static class ValitRulePropertyExtensions
    {
        public static IValitRule<TObject, TProperty> Satisfies<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, Predicate<TProperty> predicate) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            predicate.ThrowIfNull(ValitExceptionMessages.NullPredicate);

            IValitRuleAccessor<TObject, TProperty> accessor;

            if(rule.IsFirstInEnsure())
            {
                accessor = rule.GetAccessor();
                accessor.SetPredicate(predicate);
                return rule;
            }

            var newRule = new ValitRule<TObject, TProperty>(rule);
            accessor = newRule.GetAccessor();
            accessor.SetPredicate(predicate);
            
            return newRule.WithDefaultMessage(ErrorMessages.Satisifes);
        }

        public static IValitRule<TObject, TProperty> Required<TObject, TProperty>(this IValitRule<TObject, TProperty> rule) where TObject : class where TProperty : class
            => rule.Satisfies(p => p != null && !p.Equals(default(TProperty))).WithDefaultMessage(ErrorMessages.Required);

        public static IValitRule<TObject, TProperty> When<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, Predicate<TObject> condition) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            condition.ThrowIfNull(ValitExceptionMessages.NullPredicate);

            var accessor = rule.GetAccessor();

            accessor.AddCondition(condition);
            return rule;
        }

        public static IValitRule<TObject, TProperty> WithMessage<TObject, TProperty>(
            this IValitRule<TObject, TProperty> rule, Func<string> messageFunc) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            messageFunc.ThrowIfNull();

            var accessor = rule.GetAccessor();

            var error = ValitRuleError.CreateForMessage(messageFunc);
            accessor.AddError(error);
            return rule;
        }

        public static IValitRule<TObject, TProperty> WithMessage<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, string message) where TObject : class
            => rule.WithMessage(message, false);

        public static IValitRule<TObject, TProperty> WithMessageKey<TObject, TProperty, TKey>(this IValitRule<TObject, TProperty> rule, TKey messageKey) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);

            var accessor = rule.GetAccessor();
            var messageProvider = accessor.GetMessageProvider<TKey>();

            var error = ValitRuleError.CreateForMessage(() => messageProvider.GetByKey(messageKey));
            accessor.AddError(error);
            return rule;
        }

        public static IValitRule<TObject, TProperty> WithErrorCode<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, int errorCode) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);

            var accessor = rule.GetAccessor();

            var error = ValitRuleError.CreateForErrorCode(errorCode);
            accessor.AddError(error);
            return rule;
        }

        public static IValitRule<TObject, TProperty> Tag<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, params string[] tags) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            tags.ThrowIfNull();

            var accessor = rule.GetAccessor();

            accessor.AddTags(tags);
            return rule;
        }

        internal static IValitRule<TObject, TProperty> WithMessage<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, string message, bool isDefault) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            message.ThrowIfNull();

            var accessor = rule.GetAccessor();

            var error = ValitRuleError.CreateForMessage(() => message, isDefault);
            accessor.AddError(error);
            return rule;
        }       

        internal static IValitRule<TObject, TProperty> WithDefaultMessage<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, string message, params object[] @params) where TObject : class
        {
            var accessor = rule.GetAccessor();
            var memberExpression = accessor.PropertySelector.Body as MemberExpression;

            var propertyName = memberExpression != null ? memberExpression.Member.Name : string.Empty; 

            var messageParams = @params.Any() ? new [] { propertyName }.Concat(@params).ToArray() : new [] { propertyName };
            var formattedMessage = string.Format(message, messageParams);

            return rule.WithMessage(formattedMessage, true);
        }

        internal static IEnumerable<IValitRule<TObject>> GetAllEnsureRules<TObject, TProperty>(this IValitRule<TObject, TProperty> rule) where TObject : class
        {
            var rules = new List<IValitRule<TObject>> { rule };
            var previousRule = rule.GetAccessor().PreviousRule;

            while(previousRule != null)
            {
                rules.Add(previousRule);
                previousRule = previousRule.GetAccessor().PreviousRule;
            }

            rules.Reverse();
            return rules;
        }

        internal static bool IsFirstInEnsure<TObject, TProperty>(this IValitRule<TObject, TProperty> rule) where TObject : class
            => rule.GetAccessor().PreviousRule == null && ! rule.GetAccessor().HasPredicate();
    }
}
