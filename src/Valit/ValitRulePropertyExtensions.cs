using System;
using System.Collections.Generic;
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

            if(rule.IsFirstInChain())
            {
                accessor = rule.GetAccessor();
                accessor.SetPredicate(predicate);
                return rule;
            }

            var newRule = new ValitRule<TObject, TProperty>(rule);
            accessor = newRule.GetAccessor(); 
            accessor.SetPredicate(predicate);
            return newRule;
        }

        public static IValitRule<TObject, TProperty> Required<TObject, TProperty>(this IValitRule<TObject, TProperty> rule) where TObject : class where TProperty : class
        {
            return rule.Satisfies(p => p != null && !p.Equals(default(TProperty)));
        }

        public static IValitRule<TObject, TProperty> When<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, Predicate<TObject> condition) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);             
            condition.ThrowIfNull(ValitExceptionMessages.NullPredicate);

            var accessor = rule.GetAccessor();

            accessor.AddCondition(condition);            
            return rule;
        }

        public static IValitRule<TObject, TProperty> WithMessage<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, string message) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            message.ThrowIfNull();             
            
            var accessor = rule.GetAccessor();
            
            var error = ValitRuleError.CreateForMessage(message);
            accessor.AddError(error);
            return rule;
        }

        public static IValitRule<TObject, TProperty> WithMessageKey<TObject, TProperty, TKey>(this IValitRule<TObject, TProperty> rule, TKey messageKey) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);

            var accessor = rule.GetAccessor();
            var messageProvider = accessor.GetMessageProvider<TKey>();
            var message = messageProvider.GetByKey(messageKey);

            var error = ValitRuleError.CreateForMessage(message);
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

        internal static bool IsFirstInChain<TObject, TProperty>(this IValitRule<TObject, TProperty> rule) where TObject : class
            => rule.GetAccessor().PreviousRule == null;
    }
}
