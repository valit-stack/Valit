using System;
using System.Collections.Generic;
using System.Linq;
using Valit.MessageProvider;
using System.Linq.Expressions;
using Valit.Expressions;
using Valit.Strategies;

namespace Valit
{
    public static class ValitRules
    {
        public static IValitRulesStrategyPicker<TTarget> CreateFor<TTarget>(TTarget @object) where TTarget : class
        {
            var x = ValitRules<TTarget>.Create();
            x.For(@object);
            return x;
        }
    }

    public class ValitRules<TTarget> : 
        IValitRules<TTarget>,
        IValitRulesMessageProvider<TTarget>, 
        IValitRulesStrategyPicker<TTarget> 
        where TTarget : class
    {
        private TTarget _target;       
        private readonly List<IValitRule<TTarget>> _rules;
        private IValitStrategy _strategy;
        private IValitMessageProvider _messageProvider;

        private ValitRules(IEnumerable<IValitRule<TTarget>> rules)
        {   
            _rules = rules?.ToList() ?? new List<IValitRule<TTarget>>();
            _strategy = new DefaultValitStrategies().Complete;
            _messageProvider = new EmptyMessageProvider();
        }
        
        public static IValitRulesMessageProvider<TTarget> Create(IEnumerable<IValitRule<TTarget>> rules = null)
            => new ValitRules<TTarget>(rules);

        internal TTarget GetTarget() => _target;

        internal IValitStrategy GetStrategy() => _strategy;

        IValitRulesStrategyPicker<TTarget> IValitRulesMessageProvider<TTarget>.WithMessageProvider<TKey>(MessageProvider.IValitMessageProvider<TKey> messageProvider)
        {
            _messageProvider = messageProvider;
            return this;
        }

        IValitRules<TTarget> IValitRulesStrategyPicker<TTarget>.WithStrategy(IValitStrategy strategy)
        {
            _strategy = strategy;
            return this;
        }

        IValitRules<TTarget> IValitRules<TTarget>.Ensure<TProperty>(Expression<Func<TTarget, TProperty>> selector, Func<IValitRule<TTarget, TProperty>, IValitRule<TTarget, TProperty>> ruleFunc)
        {                       
            AddEnsureRulesAccessors(selector, ruleFunc);
            return this;
        }              

        IValitRules<TTarget> IValitRules<TTarget>.For(TTarget target)
        {
            target.ThrowIfNull();

            _target = target;
            return this;
        } 

        IEnumerable<IValitRule<TTarget>> IValitRules<TTarget>.GetTaggedRules()
            => _rules.Where(r => r.Tags.Any());

		IEnumerable<IValitRule<TTarget>> IValitRules<TTarget>.GetUntaggedRules()
            => _rules.Where(r => !r.Tags.Any());

        IValitResult IValitRules<TTarget>.Validate()
            => Validate(_rules);

		IValitResult IValitRules<TTarget>.Validate(params string[] tags)
		{          
            tags.ThrowIfNull();

            var taggedRules = _rules.Where(r => r.Tags.Intersect(tags).Any());

            return Validate(taggedRules);
        }

        IValitResult IValitRules<TTarget>.Validate(Func<IValitRule<TTarget>, bool> predicate)
		{
            predicate.ThrowIfNull(ValitExceptionMessages.NullPredicate);

            var taggedRules = _rules.Where(predicate);

            return Validate(taggedRules);
        }

        private IValitResult Validate(IEnumerable<IValitRule<TTarget>> rules)
        {
            _target.ThrowIfNull(ValitExceptionMessages.NullTargetObject);

            var result = ValitResult.Success;

            foreach(var rule in rules.ToList())
            {
                result &= rule.Validate(_target);

                if(!result.Succeeded)
                {
                    _strategy.Fail(rule, result, out bool cancel);

                    if(cancel)
                    {
                        break;
                    }
                }
            }

            _strategy.Done(result);

            return result;
        }

        private void AddEnsureRulesAccessors<TProperty>(Expression<Func<TTarget,TProperty>> propertySelector, Func<IValitRule<TTarget, TProperty>,IValitRule<TTarget, TProperty>> ruleFunc)
        {
            var lastEnsureRule = ruleFunc(new ValitRule<TTarget, TProperty>(propertySelector, _strategy, _messageProvider));
            var ensureRules = lastEnsureRule.GetAllEnsureRules();
            _rules.AddRange(ensureRules);
        }
	}
}
