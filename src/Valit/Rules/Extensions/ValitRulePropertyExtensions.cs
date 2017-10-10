using System;
using System.Collections.Generic;

namespace Valit
{
    public static class ValitRulePropertyExtensions
    {
        public static IValitRule<TObject, TProperty> Satisfies<TObject, TProperty>(this IValitRule<TObject, TProperty> rule, Predicate<TProperty> predicate) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            predicate.ThrowIfNull(ValitExceptionMessages.NullPredicate);

            var accessor = rule.GetAccessor(); 
            accessor.SetPredicate(predicate);

            return new ValitRule<TObject, TProperty>(rule);
        }

        public static IValitRule<TObject, TProperty> Required<TObject, TProperty>(this IValitRule<TObject, TProperty> rule) where TObject : class where TProperty : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);
            return rule.Satisfies(p => p != null && !p.Equals(default(TProperty)));
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

            previousRuleAccessor.AddErrorMessage(message);
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

        internal static IValitRule<TObject, TProperty> NotNull<TObject, TProperty>(this IValitRule<TObject, TProperty> rule) where TObject : class
        {
            rule.ThrowIfNull(ValitExceptionMessages.NullRule);    
            return rule;
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
