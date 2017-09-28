using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Valit
{
    public class ValitRules<TObject> : IValitRules<TObject>, IValitRulesStrategyPicker<TObject> where TObject : class
    {
        private TObject _object;       
        private readonly List<IValitRule<TObject>> _rules;
        private ValitRulesStrategies _strategy;

        private ValitRules(IEnumerable<IValitRule<TObject>> rules)
        {   
            _rules = rules?.ToList() ?? new List<IValitRule<TObject>>();
            _strategy = ValitRulesStrategies.Complete;
        }

        public static IValitRulesStrategyPicker<TObject> Create(IEnumerable<IValitRule<TObject>> rules = null)
            => new ValitRules<TObject>(rules);

        IValitRules<TObject> IValitRulesStrategyPicker<TObject>.WithStrategy(ValitRulesStrategies strategy)
		{
			_strategy = strategy;
            return this;
		}

        IValitRules<TObject> IValitRules<TObject>.Ensure<TProperty>(Func<TObject, TProperty> selector, Func<IValitRule<TObject, TProperty>,IValitRule<TObject, TProperty>> ruleFunc)
        {                       
            AddEnsureRulesAccessors(selector, ruleFunc);
            return this;
        }

        IValitRules<TObject> IValitRules<TObject>.For(TObject @object)
        {
            @object.ThrowIfNull();
            _object = @object;
            return this;
        } 

        IEnumerable<IValitRule<TObject>> IValitRules<TObject>.GetTaggedRules()
            => _rules.Where(r => r.Tags.Any());

		IEnumerable<IValitRule<TObject>> IValitRules<TObject>.GetUntaggedRules()
            => _rules.Where(r => !r.Tags.Any());

        IValitResult IValitRules<TObject>.Validate()
            => Validate(_rules);

		IValitResult IValitRules<TObject>.Validate(params string[] tags)
		{
            tags.ThrowIfNull();
            var taggedRules = _rules.Where(r => r.Tags.Intersect(tags).Any());

            return Validate(taggedRules);
        }

        IValitResult IValitRules<TObject>.Validate(Func<IValitRule<TObject>, bool> predicate)
		{
            predicate.ThrowIfNull(ValitExceptionMessages.NullPredicate);
            var taggedRules = _rules.Where(predicate);

            return Validate(taggedRules);
        }

        private IValitResult Validate(IEnumerable<IValitRule<TObject>> rules)
        {
            var result = ValitResult.CreateSucceeded();

            foreach(var rule in rules.ToList())
            {
                result &= rule.Validate(_object);

                if(_strategy == ValitRulesStrategies.FailFast && !result.Succeeded)
                {
                    break;
                }
            }               

            return result;
        }
        private void AddEnsureRulesAccessors<TProperty>(Func<TObject,TProperty> propertySelector, Func<IValitRule<TObject, TProperty>,IValitRule<TObject, TProperty>> ruleFunc)
        {
            var lastEnsureRule = ruleFunc(new ValitRule<TObject, TProperty>(propertySelector, _strategy));
            var ensureRules = lastEnsureRule.GetAllEnsureRules();
            _rules.AddRange(ensureRules);
        }
	}
}
