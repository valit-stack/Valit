using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Valit
{
    public class ValitRules<TObject> : IValitRules<TObject>, IValitRulesStrategyPicker<TObject> where TObject : class
    {
        private readonly TObject _object;       
        private readonly List<IValitRule<TObject>> _rules;
        private ValitRulesStrategies _strategy;

        private ValitRules(TObject @object)
        {
            _object = @object;      
            _rules = new List<IValitRule<TObject>>();  
        }

        public static IValitRulesStrategyPicker<TObject> For(TObject @object)
            => new ValitRules<TObject>(@object);

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

        IValitResult IValitRules<TObject>.Validate()
        {
            var result = ValitResult.CreateSucceeded();

            foreach(var rule in _rules)
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
